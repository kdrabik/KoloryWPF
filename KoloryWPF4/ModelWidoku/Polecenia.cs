﻿
using System;
using System.Windows;
using System.Windows.Input;

namespace KoloryWPF4.ModelWidoku
{

    public class ResetujCommand : ICommand
    {
        private readonly EdycjaKoloru modelWidoku;
        public ResetujCommand(EdycjaKoloru modelWidoku)
        {
            if (modelWidoku == null) throw new ArgumentNullException("modelWidoku");
            this.modelWidoku = modelWidoku;
        }


        public event EventHandler CanExecuteChanged //powiadamia o zmianie możliwości wykonania polecenia.
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter) //sprawdza, czy wykonanie polecenia jest możliwe.
        {
            return (modelWidoku.R != 0) || (modelWidoku.G != 0) || (modelWidoku.B != 0);
        }
        public void Execute(object parameter) //wykonuje zasadnicze działanie polecenia,
        {
            //EdycjaKoloru modelWidoku = parameter as EdycjaKoloru;
            //if (modelWidoku != null)
            //{
            modelWidoku.R = 0;
            modelWidoku.G = 0;
            modelWidoku.B = 0;
            //}
        }
    }


    public class LosujCommand : ICommand
    {
        private readonly EdycjaKoloru modelWidoku;
        public LosujCommand(EdycjaKoloru modelWidoku)
        {
            if (modelWidoku == null) throw new ArgumentNullException("modelWidoku");
            this.modelWidoku = modelWidoku;
        }


        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //EdycjaKoloru modelWidoku = parameter as EdycjaKoloru;
            //if (modelWidoku != null)
            //{
            Random rnd = new Random();
            modelWidoku.R = (byte)rnd.Next(0, 255);
            modelWidoku.G = (byte)rnd.Next(0, 255);
            modelWidoku.B = (byte)rnd.Next(0, 255);
            //}
        }
    }

    //public class ZakonczCommand : ICommand
    //{
    //    private readonly EdycjaKoloru modelWidoku;
    //    public ZakonczCommand(EdycjaKoloru modelWidoku)
    //    {
    //        if (modelWidoku == null) throw new ArgumentNullException("modelWidoku");
    //        this.modelWidoku = modelWidoku;
    //    }


    //    public event EventHandler CanExecuteChanged
    //    {
    //        add
    //        {
    //            CommandManager.RequerySuggested += value;
    //        }
    //        remove
    //        {
    //            CommandManager.RequerySuggested -= value;
    //        }
    //    }
    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }
    //    public void Execute(object parameter)
    //    {
    //        var w = Application.Current.Windows[0];
    //        w.Close();

    //    }
    //}

    public class RelayCommand : ICommand
    {
        #region Fields
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        #endregion // Fields
        #region Constructor
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion // Constructor
        #region ICommand Members
        //[DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null) CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null) CommandManager.RequerySuggested -= value;
            }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion // ICommand Members
    }





}