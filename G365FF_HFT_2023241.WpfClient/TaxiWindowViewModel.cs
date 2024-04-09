using G365FF_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace G365FF_HFT_2023241.WpfClient
{
    public class TaxiWindowViewModel :ObservableRecipient

    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        public RestCollection<Taxi> Taxis { get; set; }

        private Taxi selectedTaxi;

        public Taxi SelectedTaxi
        {
            get { return selectedTaxi; }
            set
            {
                if (value != null)
                {
                    selectedTaxi = new Taxi()
                    {
                        Name = value.Name,
                        TID = value.TID
                    };
                    OnPropertyChanged();
                    (DeleteTaxiCommand as RelayCommand).NotifyCanExecuteChanged();
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
        public ICommand CreateTaxiCommand { get; set; }

        public ICommand DeleteTaxiCommand { get; set; }

        public ICommand UpdateTaxiCommand { get; set; }
        public TaxiWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Taxis = new RestCollection<Taxi>("http://localhost:12932/", "taxi");
                //http://localhost:12932/
                CreateTaxiCommand = new RelayCommand(() =>
                {
                    Taxis.Add(new Taxi()
                    {
                        Name = SelectedTaxi.Name
                    });
                });

                UpdateTaxiCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Taxis.Update(SelectedTaxi);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTaxiCommand = new RelayCommand(() =>
                {
                    Taxis.Delete(SelectedTaxi.TID);
                },
                () =>
                {
                    return SelectedTaxi != null;
                });
                SelectedTaxi = new Taxi();
            }
        }
    }
}
