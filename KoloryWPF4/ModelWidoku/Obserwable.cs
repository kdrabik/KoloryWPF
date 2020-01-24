using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloryWPF4.ModelWidoku
{
    //public abstract class ObservedObject : INotifyPropertyChanged
    //{
    //    public event PropertyChangedEventHandler PropertyChanged;

    //    private void OnPropertyChanged(params string[] sProperties)
    //    {
    //        if (PropertyChanged != null)
    //        {
    //            foreach (string sProperty in sProperties)
    //                PropertyChanged(this, new PropertyChangedEventArgs(sProperty));
    //        }
    //    }
    //}

    public abstract class ObservedObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(params string[] sProperties)
        {
            if (PropertyChanged != null)
            {
                foreach (string sProperty in sProperties)
                    PropertyChanged(this, new PropertyChangedEventArgs(sProperty));
            }
        }
    }
}
