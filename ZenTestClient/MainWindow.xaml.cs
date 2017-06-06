using System;
using System.Data;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZenTestClient
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        Label[][] textBlocks;
        public MainWindow()
        {
            InitializeComponent();
        }

        private DataTable MakeTableWithAutoIncrement()
        {
            // Make a table with one AutoIncrement column.
            DataTable table = new DataTable("table");
            DataColumn idColumn = new DataColumn("id", Type.GetType("System.Int32"));
            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = 10;
            table.Columns.Add(idColumn);

            DataColumn firstNameColumn = new DataColumn("Item",
                Type.GetType("System.String"));
            table.Columns.Add(firstNameColumn);
            return table;
        }

        private void PrintTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    Console.WriteLine(row[column]);
                }
            }
        }

        //执行函数
        private void BtnExecute_Click(object sender, RoutedEventArgs e)
        {
            //DataContext = new MainWindowViewModel();

            //DllImport.Initialize();
            //bool a = DllImport.IsInitialized();
            //DllImport.AddStone(3, 3, 1);

        }

        //private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (listBox.SelectedItem != null)
        //    {
        //        MethodInfo mInfo = listBox.SelectedItem as MethodInfo;
        //        ParameterInfo[] pInfos = mInfo.GetParameters();
        //        foreach (ParameterInfo pInfo in pInfos)
        //        {
        //            pInfo.GetType();
        //            //pInfo.
        //        }
        //    }
        //}

        private void ShowArray(int[] array)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (array == null)
                {
                    return;
                }
                int index = 0;
                //TODO：更改立即数19
                for (int i = 0; i < 19; i++)
                {
                    for (int j = 0; j < 19; j++)
                    {
                        textBlocks[i][j].Content = array[index].ToString();
                        index++;
                    }
                }
            }));
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            textBlocks = new Label[19][];
            int order = 0;
            for (int i = 0; i < 19; i++)
            {
                textBlocks[i] = new Label[19];
                for (int j = 0; j < 19; j++)
                {
                    textBlocks[i][j] = new Label()
                    {
                        Background = (order++) % 2 == 0 ? Brushes.Wheat : Brushes.White,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        Padding = new Thickness(0)
                    };
                    arrayGrid.Children.Add(textBlocks[i][j]);
                }
            }

          (DataContext as MainWindowViewModel).ArrayChanged += ShowArray;
        }
    }
}
