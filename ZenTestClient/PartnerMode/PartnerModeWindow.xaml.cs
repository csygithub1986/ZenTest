﻿using System;
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
            m_Board.BoardMode = BoardMode.AutoPlaying;
            PartnerModeConfigDialog w = new PartnerModeConfigDialog();
            w.DataContext = this.DataContext;
            w.Owner = this;
            w.ShowDialog();
            if (w.DialogResult == true)
            {
                PartnerModeCalculator cal = new PartnerModeCalculator((DataContext as PartnerModeVM).PlayerSettings, (DataContext as PartnerModeVM).GameLoopTimes, 19);
                cal.GameOverCallback = GameOver;
                cal.UICallback = Play;
                cal.TerritoryCallback = ShowTerritory;
                cal.Start();

            }
        }

        private void ShowTerritory(int[] territory)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                m_BoardAnalyse.ShowAffects(territory);
            }));
        }

        /// <summary>
        /// stepNum, x, y, isPass, isResign
        /// </summary>
        /// <param name="stepNum"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="isPass"></param>
        /// <param name="isResign"></param>
        private void Play(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                if (stepNum == 0)
                {
                    m_Board.InitGame();
                }
                m_Board.Play(x, y, 2 - stepNum % 2);
            }));
        }

        private void GameOver(int stepNum, int x, int y, bool isPass, bool isResign)
        {
            MessageBox.Show("Over");

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}