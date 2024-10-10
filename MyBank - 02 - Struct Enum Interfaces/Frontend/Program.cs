using System;
using System.Collections.Generic;
using Backend;
using Backend.Accounts;
using Backend.Customers;

namespace Frontend
{
    class Program
    {
        static Bank MyBank = new ();
        
                        
        static void Main(string[] args)
        {
            Console.Clear();
            int option;

            do{

               Console.WriteLine("What do you want to do?");
               Console.WriteLine("------------------------");
               Console.WriteLine("1: Create Customer");
               Console.WriteLine("2: Create Current Account");
               Console.WriteLine("3: Create Saving Account");
               Console.WriteLine("4: Create Bank Card");
               Console.WriteLine("5: Create Credit Card");
               Console.WriteLine("6: Add Customer To Current Account");
               Console.WriteLine("0: EXIT");
               Console.WriteLine("");
               Console.WriteLine("Your Choise:");
               String response = Console.ReadLine();

               try{
                   option = Int32.Parse(response);
               }
               catch{
                    option = -1;
                    Console.WriteLine("Not a valid choise");
               }


               switch(option){
                   case 1:
                        Console.Clear();
                        MyBank.CreateCustomer();
                        ShowList(MyBank.CusomerList);
                        
                        break;
                    case 2:
                        MyBank.CreateCurrentAccount();
                        ShowList(MyBank.CurrentAccountList);
                        break;
                    case 3:
                        MyBank.CreateSavingAccount();
                        ShowList(MyBank.SavingAccountList);
                        break;
                    case 4:
                        CurrentAccount ca4 = ChooseFromList(MyBank.CurrentAccountList);
                        Customer c4 = null;
                        if(ca4 is not null){
                            c4 = ChooseFromList(ca4.Customers);
                        }
                        if(ca4 is not null){
                            MyBank.AddBankCardToCurrentAccount(ca4,c4);
                        }
                        ShowList(MyBank.CurrentAccountList);
                        break;
                    case 5:
                        Customer c5 = ChooseFromList(MyBank.CusomerList);
                        if(c5 is not null){
                            MyBank.CreateCreditCard(c5);
                        }
                        ShowList(MyBank.CreditCardList);
                        break;
                    case 6:
                        Customer c6 = ChooseFromList(MyBank.CusomerList);
                        CurrentAccount ca6 = null;
                        if(c6 is not null){
                            ca6 = ChooseFromList(MyBank.CurrentAccountList);
                        }
                        if(ca6 is not null){
                            MyBank.AddCustomerToAccount(ca6,c6);
                        }
                        ShowList(MyBank.CurrentAccountList);
                        break;
                    default:
                        break;
               }

            }while(option != 0);

        }

        static void ShowList<T>(List<T> list){
            Console.Clear();
            Console.WriteLine("All Objects");
            Console.WriteLine("------------------------");
            foreach(dynamic c in list){
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Press key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }

        static T ChooseFromList<T>(List<T> list){
            Console.Clear();
            Console.WriteLine("Choose from list");
            Console.WriteLine("------------------------");
            int i = 0;
            foreach(dynamic c in list){
                Console.Write($"{i}: ");
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Your Choise:");
            try{
                int choise = Int32.Parse(Console.ReadLine());
                return list[choise];
            }
            catch{
                return default(T);
            }
        }
    }
}
