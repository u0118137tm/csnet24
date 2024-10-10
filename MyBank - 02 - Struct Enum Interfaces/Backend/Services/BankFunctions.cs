using System;
using System.Collections.Generic;
using System.Diagnostics;
using Backend.Customers;
using Backend.Transactions;

namespace Backend.Services
{
    public class BankFunctions
    {
        public static String generateNumber(int length){
            Random r = new Random();
            String number = "";
            for (int i = 0; i < length; i++){
                number = String.Concat(number, r.Next(10).ToString());
            }
            return number;
        }

        public static void ContactCusomers(List<Customer> customers, String title, String message){
            foreach(Customer c in customers){
                String content = title + ": Dear ";
                switch(c.Gender){
                    case Gender.Female:
                        content += "Madam ";
                        break;
                    case Gender.Male:
                        content += "Mister ";
                        break;
                }
                content += c.Name + ", " + message;

                if((c.Contact & Contact.Phone) != 0){
                    Trace.WriteLine("Contacting over phone: ", "Info");
                    Trace.WriteLine(content, "Info");
                }

                if((c.Contact & Contact.Email) != 0){
                    Trace.WriteLine("Contacting via email: ", "Info");
                    Trace.WriteLine(content, "Info");
                }

                if((c.Contact & Contact.Whatsapp) != 0){
                    Trace.WriteLine("Contacting using Whatsapp: ", "Info");
                    Trace.WriteLine(content, "Info");
                }
            }
        }

        public static void DoTransaction(ICanTransaction from, ICanTransaction to, double amount){
            if(from.TransactionFrom(amount)){
                to.Balance += amount;
                Transaction transaction = new Transaction(){From = from, To = to, Amount = amount, TransactionDate=DateTime.Now};
                from.Transactions.Add(transaction);
                to.Transactions.Add(transaction);
                Trace.WriteLine($"Transaction from {from.Number} (new balance {from.Balance}) to {to.Number} (new balance {to.Balance}) of {amount} successful","Info");
            }
            else{
                Trace.WriteLine($"Transaction from {from.Number} to {to.Number} of {amount} NOT successful","Error");
            }
        }
    }
}