using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace G365FF_HFT_2023241.WpfClient
{
    public class MainWindowViewModel: ObservableRecipient
    {
        public ICommand PassengerWindowCommand { get; set; }
        public ICommand RideWindowCommand { get; set; }
        public ICommand TaxiWindowCommand { get; set; }
        public MainWindowViewModel()
        {
            PassengerWindowCommand = new RelayCommand(() => new PassengerWindow().Show());
            RideWindowCommand = new RelayCommand(() => new RideWindow().Show());
            TaxiWindowCommand = new RelayCommand(() => new TaxiWindow().Show());
        }
    }
}
