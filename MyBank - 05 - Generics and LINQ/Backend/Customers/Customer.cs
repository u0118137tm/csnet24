using System;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Services;

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

    public class EmptyException : Exception{
        public String Name { get; set; }
    }
    public class NotANumberException : Exception{
        public String Name { get; set; }
        public String Value { get; set; }
    }
    public class NotOldEnoughException : Exception{
        public String Age { get; set; }
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

            Console.WriteLine("Name:");
            Name = Console.ReadLine();
            if(Name.Equals("")){
                throw new EmptyException(){Name="Name"};
            }


            Console.WriteLine("Phone Number:");
            PhoneNumber = Console.ReadLine();
            double num;
            if(!double.TryParse(PhoneNumber,out num)){
                throw new NotANumberException(){Name="PhoneNumber", Value=PhoneNumber};
            }


            Console.WriteLine("Birtday (mm/dd/yyyy)");
            try{
                Birthday = Convert.ToDateTime(Console.ReadLine());
            }
            catch(FormatException){
                throw new FormatException("Birthday in the wrong format");
            }

            var today = DateTime.Today;
            var age = today.Year - Birthday.Year;
            if(Birthday.Date > today.AddYears(-age)) age--;
            if(age < 8 ){
                throw new NotOldEnoughException(){Age = age.ToString()};
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


            //Delegate containing all methods in the welcome package
            SendWelcome welcome = BankFunctions.SendWelcomeEmail;
            welcome += BankFunctions.SendCoupon;

            if(age < 18){
                welcome += BankFunctions.SendChocolate;
            }
            else{
                welcome += BankFunctions.SendWine;
            }
            BankFunctions.SendWelcomePackage(welcome);


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