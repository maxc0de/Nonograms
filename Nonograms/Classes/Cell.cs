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
    class Cell : TextBox
    {
        bool marked;
        bool skipped;
        public bool Marked
        {
            get
            {
                return marked;
            }
            set
            {
                marked = value;

                if (value)
                {
                    Skipped = false;
                    Background = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    Background = new SolidColorBrush(Colors.White);
                }
            }
        }
        public bool Skipped
        {
            get
            {
                return skipped;
            }
            set
            {
                skipped = value;

                if (value)
                {
                    Marked = false;
                    Background = new SolidColorBrush(Colors.LightGray);
                }
                else
                {
                    Background = new SolidColorBrush(Colors.White);
                }
            }
        }
        public Cell()
        {
            this.Height = 20;
            this.Width = 20;
            this.PreviewMouseDown += Cell_MouseDown;
            this.Cursor = Cursors.Arrow;
            this.IsReadOnly = true;
        }
        public Cell(bool isPicCell) : this()
        {
            if (isPicCell)
            {
                Marked = true;
            }
            else
            {
                Background = new SolidColorBrush(Colors.Gray);
                IsEnabled = false;
            }
        }

        private void Cell_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                (sender as Cell).Marked = !(sender as Cell).Marked;
            }

            if (e.RightButton == MouseButtonState.Pressed)
            {
                (sender as Cell).Skipped = !(sender as Cell).Skipped;
            }

        }
    }
}
