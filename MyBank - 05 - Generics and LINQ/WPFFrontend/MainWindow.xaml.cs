using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using Backend.Services;

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
            ConsoleTraceListener listener = new ConsoleTraceListener();
            Trace.Listeners.Add(listener);

            MyBank = new Bank();

            InitializeComponent();

            CreateCurrentAccount.Click += CreateCurrentAccountMethod;
            DeleteCurrentAccount.Click += DeleteCurrentAccountMethod;
            PrintCurrentAccount.Click += PrintCurrentAccountMethod;

            DataContext = MyBank;

            LoadDataAsync();

        }




        public void CreateCurrentAccountMethod(object sender, RoutedEventArgs args){
            MyBank.CreateCurrentAccount();
        }

        public void DeleteCurrentAccountMethod(object sender, RoutedEventArgs args){
            MyBank.DeleteCurrentAccount(MyBank.SelectedAccount);
        }
        public void PrintCurrentAccountMethod(object sender, RoutedEventArgs args){
            CurrentAccount ca  = (CurrentAccount)CurrentAccountListView.SelectedItem;
            MessageBox.Show(ca.ToString());
        }

        public async void LoadDataAsync(){
            CreateCurrentAccount.IsEnabled = false;
            Task<ObservableCollection<CurrentAccount>> ReadCurrentAccountTask = GenericReadWrite.ReadAsync<CurrentAccount>("CurrentAccounts.txt");
            MessageBox.Show("Loading Data");
            await ReadCurrentAccountTask;
            
            MyBank.CurrentAccountCollection = ReadCurrentAccountTask.Result;
            CurrentAccountListView.ItemsSource = MyBank.CurrentAccountCollection;

            CreateCurrentAccount.IsEnabled = true;
            

            
            MessageBox.Show("Loading Done");
        }

         private void LoadDataFromFile_Click(object sender, RoutedEventArgs e){
            LoadDataAsync();
        }

        public void SaveCurrentAccounts_Click(object sender, RoutedEventArgs e){
            GenericReadWrite.Save<CurrentAccount>("CurrentAccounts.txt",MyBank.CurrentAccountCollection);
            
            MessageBox.Show("Current Accounts saved");
        }
    }
}
