using System;
using System.Diagnostics;
using System.Text.Json;
using Backend.Accounts;
using Backend.Customers;

namespace Backend.Cards
{

    internal delegate CurrentAccount WithdrawMoneyDelegate(double amount);

    public class BankCard : Card
    {

        internal event WithdrawMoneyDelegate WidthdrawMoneyEvent;

        public BankCard(Customer customer) : base(customer)
        {
            Trace.WriteLine($"New BankCard created: {this.ToString()}","Info");
        }

        public void WidthdrawMoney(double amount){
            try{
                CurrentAccount ca = WidthdrawMoneyEvent.Invoke(amount);
                if(ca != null){
                    Trace.WriteLine($"{amount} widthdrawn with card {CardNumber} from account {ca.ToString()}","Info");
                }
                else{
                    Trace.WriteLine($"{amount} cannot be widthdrawn","Error");
                }
            }
            catch(NullReferenceException){
                Trace.WriteLine("Bankcard not attached to a Current Account, not able to widthraw money","Error");
            }

        }

        new public String ToString(){
            return JsonSerializer.Serialize(this);
        }
    }
}