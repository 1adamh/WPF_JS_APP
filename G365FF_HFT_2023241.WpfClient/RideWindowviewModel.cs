using G365FF_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G365FF_HFT_2023241.WpfClient
{
    public class AvgDistanceByDriver : ObservableObject
    {
        public double eredmeny1 { get; set; }
    }
    public class AvgDistanceByPassenger : ObservableObject
    {
        public double eredmeny2 { get; set; }
    }
    public class AvgCostByPassenger : ObservableObject
    {
        public double eredmeny3 { get; set; }
    }

    public class AvgDriverRide: ObservableObject
    {
        public double eredmeny4 { get; set; }
    }
    public class RideWindowviewModel : ObservableRecipient
    {
        public RestCollection<Ride> Rides { get; set; }
        public RestService RideNoncrud { get; set; }
        public ObservableCollection<AvgDistanceByDriver> AverageDrivers { get; set; }
        public ObservableCollection<AvgDistanceByPassenger> AverageDistancePassenger { get; set; }
        public ObservableCollection<AvgCostByPassenger> AverageCostPassenger { get; set; }
        public ObservableCollection<AvgDriverRide> AverageDriverRide { get; set; }


        private Ride selectedRide;

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public Ride SelectedRide
        {
            get { return selectedRide; }
            set
            {
                if (value != null)
                {
                    selectedRide = new Ride()
                    {
                        Distance = value.Distance,
                        RID = value.RID
                    };
                    OnPropertyChanged();
                    (DeleteRideCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateRideCommand { get; set; }

        public ICommand DeleteRideCommand { get; set; }

        public ICommand UpdateRideCommand { get; set; }

        public ICommand AvgDistanceByDriverCommand { get; set; }
        public ICommand AvgDistanceByPassengerCommand { get; set; }
        public ICommand AvgCostByPassengerCommand { get; set; }

        public ICommand AvgDriverRideCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public RideWindowviewModel()
        {
            if (!IsInDesignMode)
            {
                Rides = new RestCollection<Ride>("http://localhost:12932/", "ride", "hub");
                RideNoncrud = new RestService("http://localhost:12932/");
                AverageDrivers = new ObservableCollection<AvgDistanceByDriver>();
                AverageDistancePassenger = new ObservableCollection<AvgDistanceByPassenger>();
                AverageCostPassenger = new ObservableCollection<AvgCostByPassenger>();
                AverageDriverRide = new  ObservableCollection<AvgDriverRide>();

                CreateRideCommand = new RelayCommand(() =>
                {
                    Rides.Add(new Ride()
                    {
                        Distance = SelectedRide.Distance
                    });
                });

                UpdateRideCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Rides.Update(SelectedRide);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRideCommand = new RelayCommand(() =>
                {
                    Rides.Delete(SelectedRide.RID);
                },
                () =>
                {
                    return SelectedRide != null;
                });
                SelectedRide = new Ride();

                AvgDistanceByDriverCommand = new RelayCommand(
                    () =>
                    {
                        var a = RideNoncrud.Get<double>("RideStat/AvgDistanceByDriver");
                        foreach (var item in a)
                        {
                            AvgDistanceByDriver km = new AvgDistanceByDriver();
                            km.eredmeny1 = item;
                            AverageDrivers.Add(km);
                        }
                    }
                    );
                AvgDistanceByPassengerCommand = new RelayCommand(
                    () =>
                    {
                        var b = RideNoncrud.Get<double>("RideStat/AvgDistanceByPassenger");
                        foreach (var item in b)
                        {
                            AvgDistanceByPassenger pkm = new AvgDistanceByPassenger();
                            pkm.eredmeny2 = item;
                            AverageDistancePassenger.Add(pkm);
                        }


                    }
                    );

                AvgCostByPassengerCommand = new RelayCommand(
                    () =>
                    {
                        var c = RideNoncrud.Get<double>("RideStat/AvgCostByPassenger");
                        foreach (var item in c)
                        {
                            AvgCostByPassenger pcost = new AvgCostByPassenger();
                            pcost.eredmeny3 = item;
                            AverageCostPassenger.Add(pcost);
                        }
                    }
                    );

                AvgDriverRideCommand = new RelayCommand(
                    () =>
                    {
                        var d = RideNoncrud.Get<double>("RideStat/AvgDriverRide");
                        foreach (var item in d)
                        {
                            AvgDriverRide dride = new AvgDriverRide();
                            dride.eredmeny4 = item;
                            AverageDriverRide.Add(dride);

                        }
                    }
                    );
            }
        }
    }
}



