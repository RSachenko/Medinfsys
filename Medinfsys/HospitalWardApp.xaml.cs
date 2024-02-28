using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Medinfsys
{
    public class Bed : INotifyPropertyChanged
    {
        private int bedNumber;
        public int BedNumber
        {
            get { return bedNumber; }
            set
            {
                bedNumber = value;
                OnPropertyChanged(nameof(BedNumber));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class HospitalWard : INotifyPropertyChanged
    {
        private string wardName;
        public string WardName
        {
            get { return wardName; }
            set
            {
                wardName = value;
                OnPropertyChanged(nameof(WardName));
            }
        }

        private ObservableCollection<Bed> beds;
        public ObservableCollection<Bed> Beds
        {
            get { return beds; }
            set
            {
                beds = value;
                OnPropertyChanged(nameof(Beds));
            }
        }

        public HospitalWard(string wardName, ObservableCollection<Bed> beds)
        {
            WardName = wardName;
            Beds = beds;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class HospitalWardApp : Window
    {
        public ObservableCollection<HospitalWard> Wards { get; set; }

        public HospitalWardApp()
        {
            InitializeComponent();
            InitializeData();
            DataContext = this;
        }

        private void InitializeData()
        {
            Wards = new ObservableCollection<HospitalWard>
            {
                new HospitalWard("Палата 1", new ObservableCollection<Bed> { new Bed { BedNumber = 101 }, new Bed { BedNumber = 102 }, new Bed { BedNumber = 103 } }),
                new HospitalWard("Палата 2", new ObservableCollection<Bed> { new Bed { BedNumber = 201 }, new Bed { BedNumber = 202 }, new Bed { BedNumber = 203 } }),
                // Добавьте другие палаты и койки
            };
        }
    }
}
