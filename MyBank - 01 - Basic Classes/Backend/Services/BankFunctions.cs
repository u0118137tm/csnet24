using System;

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
    }
}