using interfaces;

// Cat c1 = new Cat(){Name = "Minou", Volume=100};
// Cat c2 = new Cat(){Name = "Pitou", Volume=200};
// Room r1 = new() {Volume = 500};
// Trailer t1 = new() {Volume = 500};

// Transport.Fits(c1,r1);
// Transport.Fits(c2,r1);
// Transport.Fits(t1,r1);

// Bat b1 = new();



// Speaker.MakeSound(t1);

// List<Animal> cats = new List<Animal>();

// cats.Add(new Cat(){Name = "Minou"});
// cats.Add(new Cat(){Name = "Pitou"});
// cats.Add(new Dog(){Name = "Brutus"});

// List<string> animals = new();
// animals.Add("Pitou");
// animals.Add("Minou");


// cats.Sort();

// foreach(Cat a in cats){
//     System.Console.WriteLine(a.Name);
// }


Point p1 = new Point("test"){ X=1, Y=2};
Point p2;
p2 = p1;

p2.X = 5;
p2.Name.Text = "Test 20";

System.Console.WriteLine($"Point 1 ({p1.Name.Text}): X: {p1.X}, Y: {p1.Y}");
System.Console.WriteLine($"Point 2 ({p2.Name.Text}): X: {p2.X}, Y: {p2.Y}");