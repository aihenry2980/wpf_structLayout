using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            const string outputFile = "output.txt";
            bool bSuccess = ConvertToText(tb_pdbfile.Text, outputFile);
            if (!bSuccess)
            {
                MessageBox.Show("pdb to text conversion failed!");
                return;
            }


        }

        private bool ConvertToText(string str, string outputFile)
        {
            if (!str.EndsWith(".pdb"))
            {
                MessageBox.Show("not a pdb file!");
                return false;
            }

            if (File.Exists(@str))
            {
                if (File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }

                using (StreamWriter f = new StreamWriter(outputFile))
                {
                    Process p = new Process();
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.FileName = "llvm-pdbutil.exe";
                    p.StartInfo.Arguments = "pretty -classes " + str;
                    // p.StandardOutput.copyto
                    p.Start();

                    f.WriteLine(p.StandardOutput.ReadToEnd());
                    p.WaitForExit();
                }

                if (File.Exists(outputFile))
                    return true;
            }
            return false;
        }

        private void tb_pdbfile_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.All;
            e.Handled = true;
        }

        private void tb_pdbfile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }

        private void tb_pdbfile_Drop(object sender, DragEventArgs e)
        {
            string[] fileloadup = (string[])e.Data.GetData(DataFormats.FileDrop);//Get the filename including path
            tb_pdbfile.Text = fileloadup[0];//Load data to textBox
            e.Handled = true;//This is file being dropped not copied text so we handle it
        }

        private void tb_pdbfile_Loaded(object sender, RoutedEventArgs e)
        {
            tb_pdbfile.Text = @"C:\Users\jxin\source\repos\CPP_StructLayout\Debug\CPP_StructLayout.pdb";
        }
    }
}
