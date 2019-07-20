using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Rs.App.Core30.ClientRequest.Wpf.ViewModel
{
    public abstract class AbstractViewModel : INotifyPropertyChanged
    {
        public AbstractViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
