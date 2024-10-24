using System;

namespace Backend.Transactions
{
    public struct Transaction
    {
        public ICanTransaction From;
        public ICanTransaction To;

        public double Amount;

        public DateTime TransactionDate;
    }
}