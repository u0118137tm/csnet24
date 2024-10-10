namespace interfaces
{

    public class Name{
        public string Text { get; set; }
    }

    public struct Point
    {

        public Point(string name)
        {
            this.Name = new Name(){Text = name};
        }
        public Name Name { get; set; }
        // public string Name { get; set; }
       public int X { get; set; } 
       public int Y { get; set; } 
    }
}