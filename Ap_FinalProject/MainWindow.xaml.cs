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
using IronXL;

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


            //PersonAndMoadele NewPAM = new PersonAndMoadele("amirreza", "stz", "bnb", new Moadele(int.Parse(SeparatedText[0]), int.Parse(SeparatedText[1]), int.Parse(SeparatedText[2])),new Moadele(int.Parse(SeparatedText[3]), int.Parse(SeparatedText[4]), int.Parse(SeparatedText[5])));
            //X_Value.Content = NewPAM.X;
            //Y_Value.Content = NewPAM.Y;





            int tempcounter = 3;
            while (!IsMoadele(SeparatedText[tempcounter]))
            {
                tempcounter++;
            }
            int Moadele1 = tempcounter;
            while (!IsMoadele(SeparatedText[tempcounter]))
            {
                tempcounter++;
            }
            int Moadele2 = tempcounter;
            int Zarib_Y1, Zarib_Y2, Otherside1, Otherside2;
            int Zarib_X1 = ZaribFinder(SeparatedText[Moadele1], out Zarib_Y1, out Otherside1);
            int Zarib_X2 = ZaribFinder(SeparatedText[Moadele2], out Zarib_Y2, out Otherside2);
            PersonAndMoadele NewPAM = new PersonAndMoadele(SeparatedText[0], SeparatedText[1], SeparatedText[2], new Moadele(Zarib_X1, Zarib_Y1, Otherside1), new Moadele(Zarib_X2, Zarib_Y2, Otherside2));
            X_Value.Content = NewPAM.X;
            Y_Value.Content = NewPAM.Y;
           // Text1.Text = NewPAM.X.ToString();
        }

        private int ZaribFinder(string v, out int zarib_y, out int otherside)
        {
            string StandardV = v.Replace(" ", string.Empty);
            int zarib_x = 0;
            zarib_y = 0;
            otherside = 0;
            char[] MoadeleChars = StandardV.ToCharArray();
            for (int counter = 0; counter < MoadeleChars.Length; counter++)
            {
                if (MoadeleChars[counter] == 'x' || MoadeleChars[counter] == 'X')
                {
                    int TempCounter1 = 0, TempCounter2 = counter - 1;
                    if (char.IsDigit(MoadeleChars[counter - 1]))
                    {
                        int temp = TempCounter2;
                        while (char.IsDigit(MoadeleChars[TempCounter2]) && temp >= 0)
                        {
                            zarib_x = zarib_x + (int)Math.Pow(10.00, (double)TempCounter1) * int.Parse((MoadeleChars[TempCounter2]).ToString());
                            TempCounter1++;
                            if (TempCounter2 != 0)
                                TempCounter2--;
                            temp--;
                        }
                    }
                    else zarib_x = 1;
                }
                if (MoadeleChars[counter] == 'y' || MoadeleChars[counter] == 'Y')
                {

                    if (char.IsDigit(MoadeleChars[counter - 1]))
                    {
                        int TempCounter1 = 0, TempCounter2 = counter - 1;
                        int temp = TempCounter2;
                        while (char.IsDigit(MoadeleChars[TempCounter2]) && temp >= 0)
                        {
                            zarib_y = zarib_y + (int)Math.Pow(10.00, (double)TempCounter1) * int.Parse((MoadeleChars[TempCounter2]).ToString());
                            TempCounter1++;
                            if (TempCounter2 != 0)
                                TempCounter2--;
                            temp--;
                        }
                    }
                    else zarib_y = 1;

                    if (MoadeleChars[counter] == '=')
                    {

                        for (int i = counter + 1; i < MoadeleChars.Length; i++)
                        {
                            otherside = otherside + (int)Math.Pow(10, (double)i - counter - 1) * int.Parse(MoadeleChars[i].ToString());
                        }
                    }
                }

            }
            return zarib_x;

        }

        public bool IsMoadele(string v)
        {
            string StandardV = v.Replace(" ", string.Empty);
            Y_Value.Content = StandardV;
            char[] chars = StandardV.ToCharArray();
            //foreach(char Ch in chars)
            //{
            //    if (Ch == ' ')
            //        chars.Remove(Ch);
            //}

            if (char.IsDigit(chars[0]))
            {
                if (chars[1] == 'x' || chars[1] == 'X')
                {
                    if (chars[2] == '+')
                    {
                        if (char.IsDigit(chars[3]))
                        {
                            if (chars[4] == 'y' || chars[4] == 'Y')
                            {
                                if (chars[5] == '=')
                                {
                                    if (char.IsDigit(chars[6]))
                                    {
                                        return true;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }

                        else if (chars[3] == 'y' || chars[3] == 'Y')
                        {
                            if (chars[4] == '=')
                            {
                                if (char.IsDigit(chars[5]))
                                {
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }

                    else if (chars[2] == '=')
                    {
                        if (char.IsDigit(chars[3]))
                            return true;
                        else return false;
                    }

                    else return false;
                }

                else if (chars[1] == 'y' || chars[1] == 'Y')
                {
                    if (chars[2] == '+')
                    {
                        if (char.IsDigit(chars[3]))
                        {
                            if (chars[4] == 'x' || chars[4] == 'X')
                            {
                                if (chars[5] == '=')
                                {
                                    if (char.IsDigit(chars[6]))
                                    {
                                        return true;
                                    }
                                    else return false;
                                }
                                else return false;
                            }
                            else return false;
                        }

                        else if (chars[3] == 'x' || chars[3] == 'X')
                        {
                            if (chars[4] == '=')
                            {
                                if (char.IsDigit(chars[5]))
                                {
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }

                    else if (chars[2] == '=')
                    {
                        if (char.IsDigit(chars[3]))
                            return true;
                        else return false;
                    }

                    else return false;
                }

                else return false;


            }

            else if (chars[0] == 'x' || chars[0] == 'X')
            {
                if (chars[1] == '+')
                {
                    if (char.IsDigit(chars[2]))
                    {
                        if (chars[3] == 'y' || chars[3] == 'Y')
                        {
                            if (chars[4] == '=')
                            {
                                if (char.IsDigit(chars[5]))
                                {
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }

                    else if (chars[2] == 'y' || chars[2] == 'Y')
                    {
                        if (chars[3] == '=')
                        {
                            if (char.IsDigit(chars[4]))
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }

                else if (chars[1] == '=')
                {
                    if (char.IsDigit(chars[2]))
                        return true;
                    else return false;
                }

                else return false;
            }

            else if (chars[0] == 'y' || chars[0] == 'Y')
            {
                if (chars[1] == '+')
                {
                    if (char.IsDigit(chars[2]))
                    {
                        if (chars[3] == 'x' || chars[3] == 'X')
                        {
                            if (chars[4] == '=')
                            {
                                if (char.IsDigit(chars[5]))
                                {
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }

                    else if (chars[2] == 'x' || chars[2] == 'X')
                    {
                        if (chars[3] == '=')
                        {
                            if (char.IsDigit(chars[4]))
                            {
                                return true;
                            }
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }

                else if (chars[1] == '=')
                {
                    if (char.IsDigit(chars[2]))
                        return true;
                    else return false;
                }

                else return false;
            }

            else return false;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    public class PersonAndMoadele
    {
        public string FirstName, LastName, City;
        public Moadele M1, M2;
        public double X, Y;
        public PersonAndMoadele(string firstName, string lastName, string city, Moadele m1, Moadele m2)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.City = city;
            this.M1 = m1;
            this.M2 = m2;
            this.X = ((double)(m1.OtherSide * m2.Y_zarib) - (double)(m2.OtherSide * m1.Y_zarib)) /(double) ((m2.Y_zarib * m1.X_zarib) - (double)(m1.Y_zarib * m2.X_zarib));
            this.Y = ((double)(m1.OtherSide * m2.X_zarib) - (double)(m2.OtherSide * m1.X_zarib)) /(double) ((m2.X_zarib * m1.Y_zarib) - (double)(m1.X_zarib * m2.Y_zarib));

        }


    }

    public class Moadele
    {
        public int X_zarib, Y_zarib, OtherSide;
        public Moadele(int x_zarib, int y_zarib, int otherside)
        {
            this.X_zarib = x_zarib;
            this.Y_zarib = y_zarib;
            this.OtherSide = otherside;
        }
    }
}
