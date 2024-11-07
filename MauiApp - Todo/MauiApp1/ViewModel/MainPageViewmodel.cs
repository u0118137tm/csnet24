using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace MauiApp1.ViewModel
{
    internal class MainPageViewmodel:INotifyPropertyChanged
    {
        private String _name;
        public String Name { 
            get { return _name; }
            set { _name = value; OnPropertyChanged(); }
            }

        public ObservableCollection<Todo> Todos { get; set; } = new ObservableCollection<Todo>();

        public Command AddTodo { get; set; }

        public MainPageViewmodel()
        {
            AddTodo = new Command(AddTodoMethod); 
        }

        public void AddTodoMethod()
        {
            Todos.Add(new Todo() { Name = this.Name });
            this.Name = "";
        }

        new public event PropertyChangedEventHandler PropertyChanged;
        new protected void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
