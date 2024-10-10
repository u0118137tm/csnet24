namespace delegates_events
{

    delegate void ExecuteDay();
    public class Person
    {
        public int Age {get;set;}
        public String Name {get;set;}
        public int Wage {get;set;}

        public static void Eat(){
            Console.WriteLine("Eating");
        }
        
        public static void Sleep(){
            Console.WriteLine("Sleeping");
        }
        public static void Work(){
            Console.WriteLine("Workring");
        }

    }
}