namespace interfaces
{
    public abstract class Animal: IHasVolume
    {
        public string Name { get; set; }
        public int Volume { get; set; }
        public void MakeSound(){
            System.Console.WriteLine("Silent");
        }

        public int CompareTo(Animal o){
            return this.Name.CompareTo(o.Name);
            // if(c1.Name > this.Name){
            //     return 1;
            // }
            // if(c1.Name == this.Name){
            //     return 0;
            // }
            // return -1;
        }
    }

    public abstract class Mammal: Animal{
        public int NumberOfLegs { get; set; } = 4;
    }

    public class Cat: Mammal, ICanMakeSound{
        new public void MakeSound(){
            System.Console.WriteLine("Miauw");
        }

        
    }

    

    public class Dog: Mammal, ICanMakeSound{
        new public void MakeSound(){
            System.Console.WriteLine("Woof");
        }
    }


    public class Bat: Mammal, ICanMakeSound{


        public Bat()
        {
            NumberOfLegs = 2;
        }
    }
}