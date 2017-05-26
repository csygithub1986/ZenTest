using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
//using ZenTest;

namespace ZenTestClient
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //for (int i = 0; i < 19 * 19; i++)
            //{
            //    //arrayGrid.Children.Add(new TextBlock(new Run(i + "") { }) { Background = i % 2 == 0 ? Brushes.White : Brushes.Red });
            //    arrayGrid.Children.Add(new Label() { Content = i, Background = i % 2 == 0 ? Brushes.White : Brushes.Red });
            //}
            string txt = "myzen";
            IntPtr p = Marshal.StringToCoTaskMemAuto(txt);
            DllImport.Initialize();
            bool a = DllImport.IsInitialized();
            DllImport.AddStone(3, 3, 1);
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
    }
}
