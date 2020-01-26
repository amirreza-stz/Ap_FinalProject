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

namespace Ap_FinalProject
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Text = Text1.Text;
            string[] SeparatedText = Text.Split('\n');
            //PersonAndMoadele NewPAM = new PersonAndMoadele(SeparatedText[0],SeparatedText[1],SeparatedText[2],)
        }
    }

    public class PersonAndMoadele
    {
        public string FirstName, LastName, City;
        public Moadele M1, M2;
        public double X, Y;
        public PersonAndMoadele(string firstName,string lastName,string city,Moadele m1,Moadele m2)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.M1 = m1;
            this.M2 = m2;
            this.X = ((m1.OtherSide * m2.Y_zarib) - (m2.OtherSide * m1.Y_zarib)) / ((m2.Y_zarib * m1.X_zarib) - (m1.Y_zarib * m2.X_zarib));
            this.Y = ((m1.OtherSide * m2.X_zarib) - (m2.OtherSide * m1.X_zarib)) / ((m2.X_zarib * m1.Y_zarib) - (m1.X_zarib * m2.Y_zarib));

        }


    }

   public  class Moadele
    {
        public int X_zarib, Y_zarib,OtherSide;
        public Moadele(int x_zarib,int y_zarib,int otherside)
        {
            this.X_zarib = x_zarib;
            this.Y_zarib = y_zarib;
            this.OtherSide = otherside;
        }
    }
}
