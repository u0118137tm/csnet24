using System;
using System.Diagnostics;
using Backend;
using Backend.Accounts;
using Backend.Cards;
using Backend.Customers;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            Trace.Listeners.Add(new TextWriterTraceListener(System.Console.Out, "ConsoleListener"));

            Bank MyBank = new Bank();

            Customer c1 = MyBank.CreateCustomer("User1","123456",new DateTime(2000,10,10),Gender.Female);

            Customer c2 = MyBank.CreateCustomer("User2","987654",new DateTime(2010,10,10),Gender.Male);
            Customer c3 = MyBank.CreateCustomer("User3","987654",new DateTime(2010,10,10),Gender.Other);


            MyBank.AddContactMethod(c1, Contact.Phone);
            MyBank.AddContactMethod(c1, Contact.Email);
            MyBank.AddContactMethod(c2, Contact.Whatsapp);
            MyBank.AddContactMethod(c3, (Contact)7);

            MyBank.ContactAllCustomers("Title1", "Message1");


            MyBank.RemoveContactMethod(c1, Contact.Phone);
            MyBank.RemoveContactMethod(c3, (Contact)3);

            
            MyBank.ContactAllCustomers("Title2", "Message2");

            //Customer c4 = MyBank.CreateCustomer();

            CurrentAccount ca1 = MyBank.CreateCurrentAccount();
            CurrentAccount ca2 = MyBank.CreateCurrentAccount();
            MyBank.AddCustomerToAccount(ca1,c1);


            SavingAccount sa1 = MyBank.CreateSavingAccount();
            SavingAccount sa2 = MyBank.CreateSavingAccount();

            MyBank.AddCustomerToAccount(sa2,c1);
            MyBank.AddCustomerToAccount(sa2,c2);


            CurrentAccount.CheckAccountNumber("1234567890");
            CurrentAccount.CheckAccountNumber("8888888888");
            CurrentAccount.CheckAccountNumber("12345");
            SavingAccount.CheckAccountNumber("1234567890");
            SavingAccount.CheckAccountNumber("8888888888");
            SavingAccount.CheckAccountNumber("12345");



            CreditCard cc1 = new CreditCard(c1);

            BankCard bc1 = MyBank.AddBankCardToCurrentAccount(ca1,c1);
            ca2.AddBankCard(c2);


            ca1.DepositMoney(100);
            ca1.WidthdrawMoney(80);

            MyBank.RemoveCurrentAccount(ca1);

            ca1.WidthdrawMoney(30);
            ca1.WidthdrawMoney(20);

            MyBank.RemoveCurrentAccount(ca1);

            cc1.WidthdrawMoney(20);


            MyBank.RemoveBankCardFromCurrentAccount(ca1,bc1);


            MyBank.DoTransaction(ca1,ca2,100);
            MyBank.DoTransaction(cc1,ca2,100);
            MyBank.DoTransaction(ca2,ca1,50);


            MyBank.CreateCurrentAccount();
            MyBank.CreateCurrentAccount();
            MyBank.CreateCurrentAccount();
            MyBank.CreateCurrentAccount();

            MyBank.OrderCurrentAccounts();
























        }
    }
}
