namespace delegates_events
{


    public delegate Boolean CheckNumber(int Number);

    public class MyList
    {

        // public static Boolean NumberUnder30(int Number){
        //     return Number < 30;
        // }

        // public static Boolean NumberOver30(int Number){
        //     return Number > 30;
        // }

        public static List<Person> CreateSublist(List<Person> personlist, CheckNumber check){
            List<Person> people = new List<Person>();
            foreach(Person p in personlist){
                if(check.Invoke(p.Age)){
                    people.Add(p); 
                }
            }
            return people;
        }
    }
}