namespace interfaces
{
    public class Trailer: IHasVolume, ICanMakeSound
    {
        public int Volume { get; set; }

        public void MakeSound(){
            System.Console.WriteLine("Vrooom");
        }
    }
}