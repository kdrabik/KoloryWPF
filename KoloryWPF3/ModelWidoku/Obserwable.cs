﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloryWPF3.ModelWidoku
{
    //public abstract class ObservedObject : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(params string[] nazwyWłasności)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            foreach (string nazwaWłasności in nazwyWłasności)
    //                PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
    //        }
    //    }
    //}

    public abstract class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] nazwyWłasności)
        {
            if (PropertyChanged != null)
            {
                foreach (string nazwaWłasności in nazwyWłasności)
                    PropertyChanged(this, new PropertyChangedEventArgs(nazwaWłasności));
            }
        }
    }
}
