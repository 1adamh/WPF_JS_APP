using G365FF_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace G365FF_HFT_2023241.WpfClient
{
    public class RideWindowviewModel : ObservableRecipient
    {
        public RestCollection<Ride> Rides { get; set; }
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
                    SelectedRide = new Ride()
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

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        //public RideWindowviewModel()
        //{
        //    if (!IsInDesignMode)
        //    {
        //        Rides = new RestCollection<Ride>("http://localhost:12932", "ride", "hub");
        //        CreateRideCommand = new RelayCommand(() =>
        //        {
        //            Rides.Add(new Ride()
        //            {
        //                Distance = SelectedRide.Distance
        //            });
        //        });

        //        UpdateRideCommand = new RelayCommand(() =>
        //        {
        //            try
        //            {
        //                Rides.Update(SelectedRide);
        //            }
        //            catch (ArgumentException ex)
        //            {
        //                ErrorMessage = ex.Message;
        //            }

        //        });

        //        DeleteRideCommand = new RelayCommand(() =>
        //        {
        //            Rides.Delete(SelectedRide.RID);
        //        },
        //        () =>
        //        {
        //            return SelectedRide != null;
        //        });
        //        SelectedRide = new Ride();
            }
        }
    

