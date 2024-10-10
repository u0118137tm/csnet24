// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using delegates_events;

Console.WriteLine("Hello, World!");

List<Person> persons = new List<Person>();

persons.Add(new Person { Name = "JAck", Age = 20, Wage=2000});
persons.Add(new Person { Name = "Marie", Age = 21, Wage=3000});
persons.Add(new Person { Name = "Elle", Age = 15, Wage=1500});
persons.Add(new Person { Name = "Delphine", Age = 80, Wage=0});
persons.Add(new Person { Name = "Lena", Age = 31, Wage=3500});

List<Person> persons2 = new List<Person>();


persons2 = MyList.CreateSublist(persons, Number => Number > 30);

foreach(Person person in persons2){
    Console.WriteLine(person.Name + " " + person.Age);
}  


ExecuteDay day1 = Person.Eat;
day1 += Person.Work;
day1 += Person.Eat;
day1 += Person.Work;
day1 += Person.Sleep;

day1.Invoke();



