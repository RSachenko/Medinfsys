using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Medinfsys
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Point location;

        public string PersonCode { get; set; }
        public string PersonRole { get; set; }

        public Point Location
        {
            get { return location; }
            set
            {
                location = value;
                OnPropertyChanged(nameof(Location));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
