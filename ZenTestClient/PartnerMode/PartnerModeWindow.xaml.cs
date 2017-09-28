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

namespace ZenTestClient
{
    public partial class PartnerModeWindow : Window
    {
        public PartnerModeWindow()
        {
            InitializeComponent();
        }

        private void Menu_VsSelfClick(object sender, RoutedEventArgs e)
        {
            PartnerModeConfigDialog w = new PartnerModeConfigDialog();
            w.Owner = this;
            w.ShowDialog();
            if (w.DialogResult == true)
            {

            }
        }
    }
}
