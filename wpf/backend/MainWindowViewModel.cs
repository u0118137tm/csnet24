using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace backend
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;  
        
        string _name;
        public string Name { 
            get{return _name;}
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }
        public string Firstname { get; set; }

        public ObservableCollection<string> Names {get;set;} = new ObservableCollection<string>();


        public void Clicked(object sender, EventArgs e){
            Names.Add(Name);
            Name = "";
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")  
        {  
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }  

        
    }
}