namespace interfaces
{
    public class Speaker
    {
        public static void MakeSound(ICanMakeSound a){
            a.MakeSound();
        }
    }
}