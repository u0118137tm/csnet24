using System;
using System.Collections.Generic;

namespace Backend.Transactions
{
    public interface ICanTransaction
    {
        List<Transaction> Transactions { get; set; }  
        double Balance {get;set;} 

        Boolean TransactionFrom(double amount);

        String Number { get; set; }
    }
}