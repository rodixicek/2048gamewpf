using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace projekt_wpf_2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int[,] GameGrid = new int[4, 4]; // Grid
        public SquareBox[,] Squares = new SquareBox[4, 4];
        public bool isEnd = false;


        public int Score;
        public string ScoreText
        {
            get { return (string)GetValue(ScoreTextProperty); }
            set { SetValue(ScoreTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ScoreTexte
        public static readonly DependencyProperty ScoreTextProperty =
            DependencyProperty.Register("ScoreText", typeof(string), typeof(MainWindow), new PropertyMetadata(""));



        public MainWindow()
        {
            InitializeComponent();
            LoadGame();
        }

        public void LoadGame()
        {
            Score = 0;
            ScoreText = "Score: " + Score.ToString();

            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    GameGrid[x, y] = 0;
                    SquareBox square = new SquareBox(GameGrid[x, y], Brushes.White);
                    Squares[x, y] = square;
                    Grid.SetColumn(square, x);
                    Grid.SetRow(square, y);
                    Grid4x4.Children.Add(square);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                MakeTwo();
            }

            UpdateScreen();
            this.Focus();
        }

        public void MakeTwo()
        {
            bool isZero = false;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    if (GameGrid[x, y] == 0)
                        isZero = true;
                }
            }

            if (isZero)
            {
                Random rnd = new Random();
                int rndX = rnd.Next(0, 4);
                int rndY = rnd.Next(0, 4);
                if (GameGrid[rndX, rndY] == 0)
                    GameGrid[rndX, rndY] = 2;
                else
                    MakeTwo();
            }

        }

        public void UpdateScreen()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (GameGrid[x, y] != 0)
                        Squares[x, y].Number = GameGrid[x, y].ToString();
                    else
                        Squares[x, y].Number = "";
                    Squares[x, y].Color = GetColor(GameGrid[x, y]);
                }
            }
        }

        public Brush GetColor(int number)
        {
            if (number == 0)
                return Brushes.White;
            else
            {
                int r = 255;
                int g = 255;
                int b = 255;
                g -= number * 10;
                b -= number * 10;
                if (g < 0)
                {
                    g = 0;
                    b = 0;
                    r -= number * 10;
                }

                var brush = new SolidColorBrush(Color.FromArgb(255, (byte)r, (byte)g, (byte)b));
                return brush;
            }
        }

        public void MoveUp()
        {

            //pohyb
            for (int x = 0; x < 4; x++)
            {
                for (int y = 2; y > -1; y--)
                {

                    if (GameGrid[x, y] == 0 && GameGrid[x, y + 1] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x, y + 1];
                        GameGrid[x, y + 1] = 0;
                        y = 3;
                    }
                }
            }

            //sčítaní
            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (GameGrid[x, y] == GameGrid[x, y - 1])
                    {
                        GameGrid[x, y - 1] *= 2;
                        Score += GameGrid[x, y - 1];
                        GameGrid[x, y] = 0;
                    }

                }
            }

            //pohyb
            for (int x = 0; x < 4; x++)
            {
                for (int y = 2; y > -1; y--)
                {

                    if (GameGrid[x, y] == 0 && GameGrid[x, y + 1] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x, y + 1];
                        GameGrid[x, y + 1] = 0;
                        y = 3;
                    }
                }
            }
        }

        public void MoveDown()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x, y - 1] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x, y - 1];
                        GameGrid[x, y - 1] = 0;
                        y = 0;
                    }
                }
            }
            for (int x = 0; x < 4; x++)
            {
                for (int y = 2; y > -1; y--)
                {
                    if (GameGrid[x, y] == GameGrid[x, y + 1])
                    {
                        GameGrid[x, y + 1] *= 2;
                        Score += GameGrid[x, y + 1];
                        GameGrid[x, y] = 0;
                    }
                }
            }
            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x, y - 1] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x, y - 1];
                        GameGrid[x, y - 1] = 0;
                        y = 0;
                    }
                }
            }
        }

        public void MoveRight()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x - 1, y] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x - 1, y];
                        GameGrid[x - 1, y] = 0;
                        x = 0;
                    }

                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 2; x > -1; x--)
                {
                    if (GameGrid[x, y] == GameGrid[x + 1, y])
                    {
                        GameGrid[x + 1, y] *= 2;
                        Score += GameGrid[x + 1, y];
                        GameGrid[x, y] = 0;
                    }
                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x - 1, y] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x - 1, y];
                        GameGrid[x - 1, y] = 0;
                        x = 0;
                    }

                }
            }

            
        }

        public void MoveLeft()
        {
            for (int y = 0; y < 4; y++)
            {
                for (int x = 2; x > -1; x--)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x + 1, y] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x + 1, y];
                        GameGrid[x + 1, y] = 0;
                        x = 3;
                    }
                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (GameGrid[x, y] == GameGrid[x - 1, y])
                    {
                        GameGrid[x - 1, y] *= 2;
                        Score += GameGrid[x - 1, y];
                        GameGrid[x, y] = 0;
                    }
                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 2; x > -1; x--)
                {
                    if (GameGrid[x, y] == 0 && GameGrid[x + 1, y] != 0)
                    {
                        GameGrid[x, y] = GameGrid[x + 1, y];
                        GameGrid[x + 1, y] = 0;
                        x = 3;
                    }
                }
            }
        }

        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(!isEnd)
            {
                switch (e.Key)
                {
                    case Key.Up:
                        MoveUp();
                        break;
                    case Key.Down:
                        MoveDown();
                        break;
                    case Key.Right:
                        MoveRight();
                        break;
                    case Key.Left:
                        MoveLeft();
                        break;
                    case Key.B:
                        GameGrid[0, 0] = 2048;
                        break;
                    default:
                        break;

                }
            }

            ScoreText = "Score: " + Score.ToString();
            CheckForWin();
            CheckForLoss();
            if(!isEnd)
            {
                UpdateScreen();
                MakeTwo();
                UpdateScreen();    
            }
            


        }

        public void CheckForWin()
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    if (GameGrid[x, y] == 2048)
                    {
                        Box.Visibility = Visibility.Visible;
                        WinnerText.Visibility = Visibility.Visible;
                        isEnd = true;
                    }
                        
                }
            }
        }

        public void CheckForLoss()
        {
            bool canMove = false;

            for (int x = 0; x < 4; x++)
            {
                for (int y = 1; y < 4; y++)
                {
                    if (GameGrid[x, y - 1] == GameGrid[x, y])
                        canMove = true;
                }
            }
            for (int y = 0; y < 4; y++)
            {
                for (int x = 1; x < 4; x++)
                {
                    if (GameGrid[x - 1, y] == GameGrid[x, y])
                        canMove = true; 
                }
            }

            if(!canMove)
            {
                Box.Visibility = Visibility.Visible;
                LossText.Visibility = Visibility.Visible;
                isEnd = true;
            }
        }

        private void NewGameClick(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    GameGrid[x, y] = 0;
                    
                }
            }
            Score = 0;
            Box.Visibility = Visibility.Hidden;
            LossText.Visibility = Visibility.Hidden;
            WinnerText.Visibility = Visibility.Hidden;
            ScoreText = "Score: " + Score.ToString();
            isEnd = false;

            MakeTwo();
            MakeTwo();
            UpdateScreen();
            
        }
    }
}