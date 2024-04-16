using G365FF_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G365FF_HFT_2023241.WpfClient
{
    public class AvgPassByDriver : ObservableObject
    {
        public double eredmeny5 { get; set; }
    }
    public class PassengerWindowViewModel: ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Passenger> Passengers { get; set; }
        public RestService PassNonCrud { get; set; }
        public ObservableCollection<AvgPassByDriver> AvgPassByDrivers { get; set; }
        
        private Passenger selectedPassenger;

        public Passenger SelectedPassenger
        {
            get { return selectedPassenger; }
            set
            {
                if (value != null)
                {
                    selectedPassenger = new Passenger()
                    {
                        Name = value.Name,
                        PID = value.PID
                    };
                    OnPropertyChanged();
                    (DeletePassengerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public ICommand CreatePassengerCommand { get; set; }

        public ICommand DeletePassengerCommand { get; set; }

        public ICommand UpdatePassengerCommand { get; set; }
        public ICommand AvgPassByDriverCommand {  get; set; }

        public PassengerWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Passengers = new RestCollection<Passenger>("http://localhost:12932/", "passenger", "hub");
                PassNonCrud= new RestService("http://localhost:12932/");
                AvgPassByDrivers = new ObservableCollection<AvgPassByDriver>();

                
                CreatePassengerCommand = new RelayCommand(() =>
                {
                    Passengers.Add(new Passenger()
                    {
                        Name = SelectedPassenger.Name
                    });
                });

                UpdatePassengerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Passengers.Update(SelectedPassenger);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeletePassengerCommand = new RelayCommand(() =>
                {
                    Passengers.Delete(SelectedPassenger.PID);
                },
                () =>
                {
                    return SelectedPassenger != null;
                });
                SelectedPassenger = new Passenger();


                AvgPassByDriverCommand = new RelayCommand(
                    () =>
                    {
                        var e = PassNonCrud.Get<double>("PassengerStat/AvgPassByDriver");
                        foreach (var item in e)
                        {
                            AvgPassByDriver pass = new AvgPassByDriver();
                            pass.eredmeny5 = item;
                            AvgPassByDrivers.Add(pass);
                        }
                    }
                    );

                
            }
        }
    }
}
