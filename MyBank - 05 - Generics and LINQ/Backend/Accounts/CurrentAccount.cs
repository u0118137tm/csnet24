using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using Backend.Transactions;
using Backend.Cards;
using Backend.Customers;
using Backend.Services;

namespace Backend.Accounts
{
    public class CurrentAccount:Account,ICanTransaction,IComparable
    {

        public List<BankCard> BankCards { get; set; } = new List<BankCard>();
        
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public CurrentAccount(){
            AccountNumber = BankFunctions.generateNumber(accountNmberLength);
            base.SetNumber();
            Trace.WriteLine($"New CurrentAccount created {this.ToString()}","Info");
        }

        new public static Boolean CheckAccountNumber(String _number){
            if(Account.CheckAccountNumber(_number) == true && _number.Substring(0,3).Equals("123")){
                Trace.WriteLine($"CurrentAccount number {_number} is valid","Info");
                return true;
            }
            Trace.WriteLine($"CurrentAccount number {_number} is not valid","Error");
            return false;
        }

        public BankCard AddBankCard(Customer c){
            if(Customers.Contains(c)){
                BankCard b = new BankCard(c);
                BankCards.Add(b);

                b.WidthdrawMoneyEvent += WidthdrawMoneyFromBankcard;

                Trace.WriteLine($"New BankCard added to account {this.ToString()}","Info");
                return b;
            }
            Trace.WriteLine($"Customer has no access to CurrentAccount, BankCard not added {c.ToString()}","Error");
            return null;
        }

        public void WidthdrawMoney(double amount){
            if(Balance >= amount){
                Balance -= amount;
                Trace.WriteLine($"{amount} widthdrawn from account {this.ToString()}","Info");
            }
            else{
                Trace.WriteLine($"{amount} cannot be widthdrawn from account {this.ToString()}","Error");
            }
        }

        public CurrentAccount WidthdrawMoneyFromBankcard(double amount){
            if(Balance >= amount){
                Balance -= amount;
                return this;
            }
            return null;
        }

        public void DepositMoney(double amount){
            Balance += amount;
            Trace.WriteLine($"{amount} deposited to account {this.ToString()}","Info");
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }

        public int CompareTo(object obj)
        {
            CurrentAccount account = (CurrentAccount) obj;

            return this.AccountNumber.CompareTo(account.AccountNumber);
        }
    }
}