using System;
using System.Diagnostics;
using System.Text.Json;
using Backend.Customers;
using Backend.Services;

namespace Backend.Accounts
{
    public class SavingAccount:Account
    {
        public SavingAccount(){
            AccountNumber = String.Concat("123",BankFunctions.generateNumber(accountNmberLength-3));
        }


        new public void AddCustomer(Customer customer){
            base.AddCustomer(customer);

            var today = DateTime.Today;
            var age = today.Year - customer.Birthday.Year;
            if (customer.Birthday.Date > today.AddYears(-age)) age--;

            if(age < 12 && customer.FirstSavingsAccount){
                Balance += 50;
                customer.FirstSavingsAccount = false;
                Trace.WriteLine($"Customer under 12, first SavingAccount","Info");
            }

        }

        new public static Boolean CheckAccountNumber(String _number){
            if(Account.CheckAccountNumber(_number) == true){
                Trace.WriteLine($"SavingAccount number {_number} is valid","Info");
                return true;
            }
            Trace.WriteLine($"SavingAccount number {_number} is not valid","Error");
            return false;
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }
    }
}