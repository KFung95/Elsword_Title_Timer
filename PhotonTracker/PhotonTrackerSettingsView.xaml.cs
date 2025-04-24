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
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace PhotonTracker
{
    /// <summary>
    /// Interaction logic for PhotonTrackerSettingsView.xaml
    /// </summary>
    public partial class PhotonTrackerSettingsView : UserControl
    {
        public PhotonTrackerSettingsView()
        {
            InitializeComponent();
        }

        //prevent space or enter from continuously reprompting the user to bind a key
        private void UserControl_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
