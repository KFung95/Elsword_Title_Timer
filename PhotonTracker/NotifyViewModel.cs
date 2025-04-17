using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PhotonTracker
{
    public abstract class NotifyViewModel
    {
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if (propertyChangedEventHandler != null)
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
