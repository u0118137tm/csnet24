using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Customers
{
    public class Customer
    {
        static int currentId = 0;

        public int Id { get; init; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }

        [JsonIgnore]    //used to exclude property from jsonserialize
        public Boolean FirstSavingsAccount {get;set;} = true;



            public Customer(){
            Id = currentId;
            currentId++;
            do{
                Console.WriteLine("Name:");
                Name = Console.ReadLine();
            }while(Name == "");


            do{
                Console.WriteLine("Phone Number:");
                PhoneNumber = Console.ReadLine();
            }while(PhoneNumber == "");


            Boolean DateOK = false;
            while(!DateOK){
                Console.WriteLine("Birtday (dd/mm/yyyy)");
                try{
                    Birthday = Convert.ToDateTime(Console.ReadLine());
                    DateOK = true;
                }
                catch{
                    Console.WriteLine("Birthday not in correct format");
                }
                
            }
            Trace.WriteLine($"New customer created: {this.ToString()}","Info");
        }

          public Customer(String _name, String _phonenumber, DateTime _birthday){
            Id = currentId;
            currentId++;
            Name = _name;
            PhoneNumber = _phonenumber;
            Birthday = _birthday;
            Trace.WriteLine($"New customer created: {this.ToString()}","Info");
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }

    }
}