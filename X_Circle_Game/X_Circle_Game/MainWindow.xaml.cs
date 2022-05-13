using System;
using System.Collections.Generic;
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

namespace X_Circle_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int player = 0;
        char[,] mat = new char[3,3];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (e.OriginalSource as Button);
            int row = (int)b.GetValue(Grid.RowProperty);
            int col = (int)b.GetValue(Grid.ColumnProperty);
            if (b.Content.ToString() == "?")
            {
                if (player == 0)
                {
                    b.Content = "X";
                    player = 1;
                    mat[row, col] = 'X';
                    if (Win(row,col,'X'))
                    {
                        MessageBox.Show("X win!!!!!!!!!!!");
                    }
                }

                else
                {
                    b.Content = "O";
                    player = 0;
                    mat[row, col] = 'O';
                    if (Win(row, col,'O'))
                    {
                        MessageBox.Show("O win!!!!!!!!!!!");
                    }
                }
            }
        }
        private bool Win(int row,int col,char tav)
        {
            bool isWin1 = true, isWin2 = true, isWin3 = true, isWin4 = true,alachson1=false,alachson2=false;
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[row, i] != tav)
                    isWin1 = false;
            }
            
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                if (mat[i, col] != tav)
                    isWin2 = false;
            }

            if ((row==0 && col==0)||(row==mat.GetLength(0)-1 && col==mat.GetLength(0)-1)||(row== mat.GetLength(0)/2 && col == mat.GetLength(0) / 2))
            {
                alachson1 = true;
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    if (mat[i, i] != tav)
                        isWin3 = false;
                }
            }

            if ((row == mat.GetLength(0)-1 && col == 0) || (row == 0 && col == mat.GetLength(0)-1) || (row == mat.GetLength(0) / 2 && col == mat.GetLength(0) / 2))
            {
                alachson2 = true;
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    if (mat[i, mat.GetLength(0)-i-1] != tav)
                        isWin4 = false;
                }
            }
            
            if(alachson1)
               return isWin1 || isWin2 ||isWin3;
            if(alachson2)
               return isWin1 || isWin2 || isWin4;
            return isWin1 || isWin2;
        }

    }
}
