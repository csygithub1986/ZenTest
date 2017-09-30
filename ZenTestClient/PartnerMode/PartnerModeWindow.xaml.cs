using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            w.DataContext = this.DataContext;
            w.Owner = this;
            w.ShowDialog();
            if (w.DialogResult == true)
            {
                PartnerModeCalculator cal = new PartnerModeCalculator((DataContext as PartnerModeVM).PlayerSettings, (DataContext as PartnerModeVM).GameLoopTimes);
                cal.LogCallback = Log;
                cal.GameOverCallback = GameOver;

                ClientLog.FilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + DateTime.Now.ToString("MM-dd HH-mm-ss") + "~ZenVsZen.sgf";//TODO，命名
                ClientLog.WriteLog("(;WP[Zen]BP[Zen]");


                cal.Start();
            }
        }

        private void Log(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            ClientLog.WriteLog(";" + (stepNum % 2 == 1 ? "W" : "B") + "[" + (char)('a' + x) + (char)('a' + y) + "]");
            Console.WriteLine(stepNum + " : ");
        }

        private void GameOver(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            ClientLog.WriteLog(")");
            MessageBox.Show("Over");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}