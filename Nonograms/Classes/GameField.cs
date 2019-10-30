using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nonograms
{
    class GameField : UniformGrid
    {
        private int size;
        public Cell[,] cells;
        List<string[]> nonogram;

        public List<List<int>> rowsNums = new List<List<int>>();
        public List<List<int>> columnsNums = new List<List<int>>();
        private int widthRowsNums;
        private int heightColumnsNums;

        public GameField() { }
        public GameField(int size)
        {
            this.size = size;
        }
        public GameField(List<string[]> nonogram)
        {
            this.nonogram = nonogram;
            this.size = nonogram[0].Count();

            cells = new Cell[size,size];

            СalculationNums();

            //Отрисовка
            this.Rows = this.Columns = size;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (nonogram[i][j] == "1")
                    {
                        Cell cell = new Cell(true);
                        this.Children.Add(cell);
                        cells[i, j] = cell;
                    }
                    else
                    {
                        Cell cell = new Cell();
                        this.Children.Add(cell);
                        cells[i, j] = cell;
                    }
                }
            }
        }

        public GameField GetGameFieldColumns()
        {
            GameField field = new GameField();

            field.Rows = size;
            field.Columns = widthRowsNums;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < widthRowsNums; j++)
                {
                    try
                    {
                        field.Children.Add(new Cell(false)
                        {
                            Text = $"{rowsNums[i][j]}",

                        });
                    }
                    catch
                    {
                        field.Children.Add(new Cell(false)
                        {
                            Text = "",
                        });
                    }

                }
            }


            return field;
        }
        public GameField GetGameFieldRows()
        {
            GameField field = new GameField();

            field.Rows = heightColumnsNums;
            field.Columns = size;

            for (int i = 0; i < heightColumnsNums; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    try
                    {
                        field.Children.Add(new Cell(false)
                        {
                            Text = $"{columnsNums[j][i]}",
                    });
                    }
                    catch
                    {
                        field.Children.Add(new Cell(false)
                        {
                            Text = "",
                    });
                    }

                }
            }

            return field;
        }
        public GameField GetEmpty()
        {
            GameField field = new GameField();
            field.cells = new Cell[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Cell cell = new Cell();
                    field.Children.Add(cell);
                    field.cells[i, j] = cell;
                }
            }

            return field;
        }
        private void СalculationNums()
        {
            int n1 = 0;
            int n2 = 0;
            List<int> m1 = new List<int>();
            List<int> m2 = new List<int>();

            //Вычисление клеток
            for (int i = 0; i < size; i++)
            {
                n1 = 0;
                n2 = 0;
                m1 = new List<int>();
                m2 = new List<int>();

                for (int j = 0; j < size; j++)
                {

                    if (nonogram[i][j] == "1")
                    {
                        n1++;
                    }
                    else if (n1 != 0)
                    {
                        m1.Add(n1);
                        n1 = 0;
                    }


                    if (nonogram[j][i] == "1")
                    {
                        n2++;
                    }
                    else if (n2 != 0)
                    {
                        m2.Add(n2);
                        n2 = 0;
                    }
                }

                if (n1 != 0)
                {
                    m1.Add(n1);
                }

                if (n2 != 0)
                {
                    m2.Add(n2);
                }

                rowsNums.Add(m1);
                columnsNums.Add(m2);

                widthRowsNums = m1.Count > widthRowsNums ? m1.Count : widthRowsNums;
                heightColumnsNums = m2.Count > heightColumnsNums ? m2.Count : heightColumnsNums;
            }
        }
        public void Win()
        {
            foreach (var c in cells)
            {
                if (c.Marked == true)
                {
                    c.Background = new SolidColorBrush(Colors.Green);
                }
            }
        }
        public bool Equals(GameField game)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (cells[i,j].Marked != game.cells[i,j].Marked)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
