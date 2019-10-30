using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Nonograms
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static GameField game;
        static GameField empty;

        //GameField newg;
        public MainWindow()
        {
            InitializeComponent();

            ReadFromFile();

            //newg = new GameField(15).GetEmpty();

            //Game.Children.Add(newg);
            //this.SizeToContent = SizeToContent.WidthAndHeight;
        }

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        ReadFromFile(new FileInfo(openFileDialog.FileName));
        //    }
        //}

        private void ReadFromFile()
        {
            string s = "0 0 0 1 1 0 0 0 0 0 1 1 0 0 0 \r\n0 0 1 1 1 1 0 0 0 1 1 1 1 0 0 \r\n0 1 1 1 1 1 1 0 1 1 1 1 1 1 0 \r\n1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 \r\n1 0 0 0 1 1 0 1 0 1 1 0 1 0 1 \r\n1 1 0 1 1 0 0 0 0 0 1 0 1 0 1 \r\n1 1 0 1 1 1 0 0 0 1 1 0 1 0 1 \r\n1 0 0 0 1 1 1 0 1 1 1 0 0 0 1 \r\n0 1 1 1 1 1 1 1 1 1 1 1 1 1 0 \r\n0 0 1 1 1 1 1 1 1 1 1 1 1 0 0 \r\n0 0 0 1 1 1 1 1 1 1 1 1 0 0 0 \r\n0 0 0 0 1 1 1 1 1 1 1 0 0 0 0 \r\n0 0 0 0 0 1 1 1 1 1 0 0 0 0 0 \r\n0 0 0 0 0 0 1 1 1 0 0 0 0 0 0 \r\n0 0 0 0 0 0 0 1 0 0 0 0 0 0 0 \r\n";

            //using (StreamReader sr = new StreamReader(file.FullName))
            //{
            //    s = sr.ReadToEnd();
            //}

            List<string[]> nonogram = Regex.Split(s, "\r\n").Select(we => we.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).ToList();

            game = new GameField(nonogram);
            empty = game.GetEmpty();

            Top.Children.Add(game.GetGameFieldRows());
            Left.Children.Add(game.GetGameFieldColumns());
            Game.Children.Add(empty);


            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        //private void SaveToFile()
        //{
        //    using (StreamWriter sw = new StreamWriter("ilu.txt", false))
        //    {

        //        for (int i = 0; i < 15; i++)
        //        {
        //            for (int j = 0; j < 15; j++)
        //            {
        //                if (newg.cells[i, j].Marked == true)
        //                {
        //                    sw.Write($"1 ");
        //                }
        //                else
        //                {
        //                    sw.Write($"0 ");
        //                }

        //            }
        //            sw.WriteLine();
        //        }
        //    }
        //}

        public static void CheckEquals(object sender, EventArgs e)
        {
            if (game.Equals(empty))
            {
                MessageBox.Show("Я тебя люблю!");
            }
        }

        //private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        //{
        //    SaveToFile();
        //}
    }
}
