using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace G365FF_HFT_2023241.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PassengerWindow _passengerWindow;
        private RideWindow _rideWindow;
        public MainWindow()
        {
            InitializeComponent();
        }

        

       

        

        private void PassangerWindow_Closed(object sender, EventArgs e)
        {
            if (_passengerWindow!=null)
            {
                _passengerWindow.Closed -= PassangerWindow_Closed;
                _passengerWindow = null;
            }
        }

        private void RideWindow_Closed(object sender, EventArgs e)
        {
            if (_passengerWindow != null)
            {
                _rideWindow.Closed -= RideWindow_Closed;
                _rideWindow = null;
            }
        }
    }
}
