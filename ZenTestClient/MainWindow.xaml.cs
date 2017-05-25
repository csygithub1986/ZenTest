using System;
using System.Collections.Generic;
using System.Data;
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
            for (int i = 0; i < 19 * 19; i++)
            {
                //arrayGrid.Children.Add(new TextBlock(new Run(i + "") { }) { Background = i % 2 == 0 ? Brushes.White : Brushes.Red });
                arrayGrid.Children.Add(new Label() { Content = i, Background = i % 2 == 0 ? Brushes.White : Brushes.Red });
            }
            //object[] a = { 2, 2 };
            //DataTable table = MakeTableWithAutoIncrement();
            //DataRow row = table.NewRow();
            //row.ItemArray = a;
            //table.Rows.Add(row);
            //datagrid.ItemsSource = table.AsDataView();

            //DataTable dt = MakeTableWithAutoIncrement();
            //DataRow relation;
            //// Declare the array variable.
            //object[] rowArray = { 1, 2,3 };
            //// Create 10 new rows and add to DataRowCollection.
            //for (int i = 0; i < 10; i++)
            //{
            //    //rowArray[0] = null;
            //    //rowArray[1] = "item " + i;
            //    relation = dt.NewRow();
            //    relation.ItemArray = rowArray;
            //    dt.Rows.Add(relation);
            //}
            //PrintTable(dt);
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
