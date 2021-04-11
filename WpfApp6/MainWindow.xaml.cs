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
using System.ComponentModel;

namespace WpfApp6
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Zaměstnanec z;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            z = new Zaměstnanec { Name = "Beze jména", Surname = "Bez příjmení" };
            this.DataContext = z;
            NameErrorLabel.DataContext = this;
            SurnameErrorLabel.DataContext = this;
        }
        private bool CheckNameOK()
        {
            if (z.Name.Length > 0)
            {
                NameErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                NameErrorVisible = Visibility.Visible;
                return false;
            }
        }
        private bool CheckSurnameOK()
        {
            if (z.Surname.Length > 0 && z.Surname.Length < 20)
            {
                SurnameErrorVisible = Visibility.Hidden;
                return true;
            }
            else
            {
                SurnameErrorVisible = Visibility.Visible;
                return false;
            }
        }
        private Visibility _SurnameErrorVisible;
        public Visibility SurnameErrorVisible
        {
            get { return _SurnameErrorVisible; }
            set
            {
                _SurnameErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SurnameErrorVisible"));
            }
        }
        private string _SurnameError = "Příjmení je povinna položka.";
        public string SurnameError
        {
            get { return _SurnameError; }
            set
            {
                if (z.Surname.Length < 2)
                {
                    _SurnameError = "Jméno nemůže být kratší než 2 znaky.";
                }
                else if (z.Surname.Length > 20)
                {
                    _SurnameError = "Jméno nemůže být delší než 20 znaky.";
                }
                else
                {
                    _SurnameError = "";
                    PropertyChanged(this, new PropertyChangedEventArgs("SurnameError"));
                }
            }
        }


        private Visibility _NameErrorVisible;
        public Visibility NameErrorVisible
        {
            get { return _NameErrorVisible; }
            set
            {
                _NameErrorVisible = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NameErrorVisible"));
            }
        }
        private string _NameError = "Jméno je povinna položka.";
        public string NameError { get { return _NameError; } }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Jméno: {z.Name}\nPříjmení: {z.Surname}\nTřída: {(Vzdelani.SelectedItem as ComboBoxItem).Content}\n{z.BirthDate}\n{z.Job}\n{z.Salary}");
            Zaměstnanec.AllEmployers.Add(z);
            z = new Zaměstnanec { Name = "Nic", Surname = "Nic" };
            this.DataContext = z;
        }

        private void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckNameOK();
        }

        private void Surname_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckSurnameOK();
        }

    }
}
