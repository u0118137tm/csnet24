using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Backend.Customers;

namespace Backend.Accounts
{
    public abstract class Account
    {

        public String AccountNumber { get; set; }
        public double Balance { get; set; } = 0;
        public List<Customer> Customers { get; set; } = new List<Customer>();

        protected const int accountNmberLength = 10;


        public Customer this[int index]{
            get{
                foreach(Customer c in Customers){
                    if(c.Id == index){
                        return c;
                    }
                }
                return null;
            }
        }


        public void AddCustomer(Customer customer){
            if(!Customers.Contains(customer)){
                Customers.Add(customer);
                Trace.WriteLine($"Customer added to account: {this.ToString()}","Info");
            }
            else{
                Trace.WriteLine($"Customer already member of account","Warning");
            }
        }

        public static Boolean CheckAccountNumber(String _number){
            if(_number.All(char.IsDigit) && _number.Length == accountNmberLength){
                return true;
            }
            return false;
        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }
        
    }
}