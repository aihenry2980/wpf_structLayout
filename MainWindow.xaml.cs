using System;
using System.Collections.Generic;
using System.IO;
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

namespace wpf_structLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dg_output_Loaded(object sender, RoutedEventArgs e)
        {
            string[] labels = new string[] { 
                "  ",
                "15", 
                "14", 
                "13",
                "12",
                "11",
                "10",
                "9",
                "8",
                "7",
                "6",
                "5",
                "4",
                "3",
                "2",
                "1",
                "0"

            };

            foreach (string label in labels)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = label;
                column.Binding = new Binding(label.Replace(' ', '_'));

                dg_output.Columns.Add(column);
            }
        }

        private void bt_analyze_Click(object sender, RoutedEventArgs e)
        {
            var str = tb_pdbfile.Text;
            if (File.Exists(@str))
            {
                using (StreamWriter file = new StreamWriter("mypics.txt"))
                {
                    p.StandardOutput.CopyTo(file);
                }
                System.Diagnostics.Process.Start("llvm-pdbutil.exe", "pretty -all "+str+" > output.txt");
            }
        }
    }
}
