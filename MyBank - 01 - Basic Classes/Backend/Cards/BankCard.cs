using System;
using System.Diagnostics;
using System.Text.Json;
using Backend.Customers;

namespace Backend.Cards
{
    public class BankCard : Card
    {
        public BankCard(Customer customer) : base(customer)
        {
            Trace.WriteLine($"New BankCard created: {this.ToString()}","Info");
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }
    }
}