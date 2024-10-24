using System;
using Backend.Customers;
using Backend.Services;

namespace Backend.Cards
{
    public class Card
    {
        public String CardNumber { get; set; }
        int pin;
        public Customer Customer { get; set; }

        const int cardNumberLength = 8;

        public Card(Customer customer){
            Customer = customer;
            CardNumber = BankFunctions.generateNumber(cardNumberLength);
        }
    }
}