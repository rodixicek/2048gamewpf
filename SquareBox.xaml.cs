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

namespace projekt_wpf_2048
{
    /// <summary>
    /// Interaction logic for SquareBox.xaml
    /// </summary>
    public partial class SquareBox : UserControl
    {


        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(SquareBox), new PropertyMetadata(""));



        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(Brush), typeof(SquareBox), new PropertyMetadata(Brushes.White));



        public SquareBox(int number, Brush color)
        {
            if (number != 0)
                Number = number.ToString();
            else
                Number = "";
            Color = color;

            InitializeComponent();
        }
    }
}
