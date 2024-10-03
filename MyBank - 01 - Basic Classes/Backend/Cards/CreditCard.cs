using System;
using System.Diagnostics;
using System.Text.Json;
using Backend.Customers;

namespace Backend.Cards
{
    public class CreditCard : Card
    {

        int cvcCode;
        public double Balance { get; set; }

        public CreditCard(Customer customer):base(customer){
            try{
                cvcCode = Int32.Parse(CardNumber)%987;
                Trace.WriteLine($"New CreditCard created: {this.ToString()}","Info");
            }
            catch{
                Trace.WriteLine($"CardNumber {CardNumber} is not a valid number","Error");
            }
        }


        ///<summary>Method withdraws money from the balance</summary>
        ///<param="amount">The amount of money to be withrawn</param> 
        public void WidthdrawMoney(double amount){
            if(Balance >= amount){
                Balance -= amount;
                Trace.WriteLine($"{amount} widthdrawn from card {this.ToString()}","Info");
            }
            else{
                Trace.WriteLine($"{amount} cannot be widthdrawn from card {this.ToString()}","Error");
            }
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }
        
    }
}