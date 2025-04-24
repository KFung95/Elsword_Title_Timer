using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotonTracker
{
    /// <summary>
    /// Interaction logic for PhotonTrackerView.xaml
    /// </summary>
    public partial class PhotonTrackerView : Window
    {
        public PhotonTrackerView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            photonTrackerGrid.Focus();
        }
    }
}