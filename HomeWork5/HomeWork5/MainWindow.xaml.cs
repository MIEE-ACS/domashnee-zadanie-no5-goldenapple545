using System;
using System.Collections.Generic;
using System.Linq;
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

namespace HomeWork5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public class Complex
    {
        public Complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        private double real;
        private double imag;

        public void sum(Complex a)
        {
            this.real += a.real;
            this.imag += a.imag;
        }

        public void sub(Complex a)
        {
            this.real -= a.real;
            this.imag -= a.imag;
        }

        public void multiply(Complex a)
        {
            double tempReal = this.real * a.real - this.imag * a.imag;
            this.imag = this.real * a.imag + this.imag * a.real;
            this.real = tempReal;
        }

        public string toString()
        {
            return $"{this.real} + {this.imag}i";
        }
    }

 
    public partial class MainWindow : Window
    {
        Complex GetComplex(string a, string b)
        {
            double real, imag;

            if (a == "") a = "0";
            if (b == "") b = "0";

            if (double.TryParse(a, out real) && double.TryParse(b, out imag))
            {
                return new Complex(real, imag);
            }
            else
            {
                Warning.Content = "Неправильный ввод данных!";
                return new Complex(0, 0);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Warning.Content = "";
            Complex a = GetComplex(textAReal.Text, textAImg.Text);
            Complex b = GetComplex(textBReal.Text, textBImg.Text);

            switch (ComboBox.SelectedIndex)
            {
                case 0:
                    a.sum(b);
                    Answer.Content = a.toString();
                    break;
                case 1:
                    a.sub(b);
                    Answer.Content = a.toString();
                    break;
                case 2:
                    a.multiply(b);
                    Answer.Content = a.toString();
                    break;
            }
        }

        //private void textAReal_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (textAReal.Text == "Real")
        //        textAReal.Text = "";
        //}
    }
}
