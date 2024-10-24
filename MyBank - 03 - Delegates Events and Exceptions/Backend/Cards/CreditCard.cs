using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Backend.Customers;
using Backend.Transactions;

namespace Backend.Cards
{
    public class CreditCard : Card, ICanTransaction
    {

        int cvcCode;
        public double Balance { get; set; }

        [JsonIgnore]
        public String Number { get; set; }

        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CreditCard(Customer customer):base(customer){
            try{
                cvcCode = Int32.Parse(CardNumber)%987;
                Number = CardNumber;
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

        public bool TransactionFrom(double amount)
        {
            Balance -= amount;
            return true;
        }
    }
}