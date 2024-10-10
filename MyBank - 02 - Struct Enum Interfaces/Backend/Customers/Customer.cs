using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Customers
{

    public enum Gender : byte{
        Female = 1,
        Male = 2,
        Other
    }

    [Flags]
    public enum Contact{
        Phone = 1,
        Email = 2,
        Whatsapp = 4
    }

    public class Customer
    {
        static int currentId = 0;

        public int Id { get; init; }
        public String Name { get; set; }
        public String PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public Gender Gender { get; set; }

        public Contact Contact { get; set; } = 0;

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

            do{
                Console.WriteLine("Choose the gender");
                foreach (Gender gender in Enum.GetValues(typeof(Gender))){
                    System.Console.Write($"{(byte)gender}: ");
                    System.Console.WriteLine(gender.ToString());
                }
                try{
                    Gender = (Gender)Byte.Parse(Console.ReadLine());
                }
                catch{
                    Console.WriteLine("Not a valid gender");
                    Gender = 0;
                }
            }while(Gender == 0);

            Trace.WriteLine($"New customer created: {this.ToString()}","Info");
        }

          public Customer(String _name, String _phonenumber, DateTime _birthday, Gender _gender){
            Id = currentId;
            currentId++;
            Name = _name;
            PhoneNumber = _phonenumber;
            Birthday = _birthday;
            Gender = _gender;
            Trace.WriteLine($"New customer created: {this.ToString()}","Info");
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }

    }
}