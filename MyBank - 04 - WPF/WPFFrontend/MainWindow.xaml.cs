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
using Backend;
using Backend.Accounts;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Bank MyBank;
        public MainWindow()
        {

            MyBank = new Bank();

            InitializeComponent();

            CreateCurrentAccount.Click += CreateCurrentAccountMethod;
            PrintCurrentAccount.Click += PrintCurrentAccountMethod;

            DataContext = MyBank;

        }


        public void CreateCurrentAccountMethod(object sender, RoutedEventArgs args){
            MyBank.CreateCurrentAccount();
        }
        public void PrintCurrentAccountMethod(object sender, RoutedEventArgs args){
            CurrentAccount ca  = (CurrentAccount)CurrentAccountListView.SelectedItem;
            MessageBox.Show(ca.ToString());
        }
    }
}
