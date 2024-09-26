using classlib;

namespace console
{
    public class Menu
    {
        public static int ShowMainMenu(){

            int choise;
            do{
                Console.Clear();
                Console.WriteLine("Notes");
                Console.WriteLine("");
                Console.WriteLine("1: Create new note");
                Console.WriteLine("2: Show all notes");
                Console.WriteLine("3: Get note title and priority (tuples)");
                Console.WriteLine("4: Get note title and text (out)");
                Console.WriteLine("5: Get note importance");
                Console.WriteLine("6: Get note length");
                Console.WriteLine("7: Add Tags to note");
                Console.WriteLine("8: Show note tags");
                Console.WriteLine("9: Save note to text file");
                Console.WriteLine("10: Restore note from text file");
                Console.WriteLine("");
                Console.WriteLine("0: exit");

                String input = Console.ReadLine();
                try{
                    choise = int.Parse(input);
                    return choise;
                }
                catch{
                    choise = -1;
                }
            }while(choise == -1);
            return -1;
        }

        public static Note CreateNewNote(){
            Note note;
            Console.Clear();
            Console.WriteLine("Create New Note");
            Console.WriteLine("");
            Console.WriteLine("Title:");
            String title = Console.ReadLine();
            Console.WriteLine("Text:");
            String text = Console.ReadLine();
            int priority;
            Console.WriteLine("Priority (0-10):");
            String prioritystring = Console.ReadLine();
            try{
                priority = int.Parse(prioritystring);
                note = new Note(title,text,priority);

            }
            catch{
                note = new Note(title,text);
            }

            return note;
        }

        public static void ShowAllNotes(List<Note> notes){
            Console.Clear();
            Console.WriteLine("All Notes");
            Console.WriteLine("");
            foreach(Note note in notes){
                Console.Write(note.Id);
                Console.Write(", ");
                Console.Write(note.Title);
                Console.Write(", ");
                Console.Write(note.Text);
                Console.Write(", ");
                Console.Write(note.Priority);
                Console.Write(", ");
                Console.WriteLine(String.Join(",",note.Tags));
            }
            Console.ReadLine();
            
        } 

        public static void GetNoteTitlePriority(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Get note title and priority");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                (string, int) val = notes[notenumber].GetTitlePriority();
                Console.WriteLine("Title: " + val.Item1);
                Console.WriteLine("Priority: " + val.Item2);
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

         public static void GetNoteTitleText(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Get note title and text");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                notes[notenumber].GetTitleText(out String title, out String text);
                Console.WriteLine("Title: " + title);
                Console.WriteLine("Text: " + text);
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

        public static void GetNoteImportance(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Get note importance");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                Console.WriteLine("Note importance: " + notes[notenumber].GetImportance());
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

        public static void GetNoteLength(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Get note length");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                Console.WriteLine("Note length: " + notes[notenumber].GetNoteLength());
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

        public static void AddTags(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Add tags to note");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                Console.WriteLine("Give all tags seperated by ,");
                input = Console.ReadLine();
                String[] tags = input.Split(",");
                notes[notenumber].AddTags(tags);
            }
            catch(Exception e){
                Console.WriteLine("Invalid Input: " + e.Message);
            }
            Console.ReadLine();

        }

        public static void GetAllTags(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Get note Tags");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                Console.WriteLine("Note tags: " + String.Join(",",notes[notenumber].Tags));
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

         public static void SaveNoteToText(List<Note> notes){
            Console.Clear();
            Console.WriteLine("Save note to textfile");
            Console.WriteLine("");
            Console.WriteLine("Select Note");
            Console.WriteLine("");
            Menu.ListAllNotes(notes);
            String input = Console.ReadLine();
            try{
                int notenumber = int.Parse(input);
                Console.WriteLine("filename: ");
                String filename = Console.ReadLine();

                Note.SaveNoteToText(notes[notenumber], filename);
                Console.WriteLine("Note Saved");
            }
            catch{
                Console.WriteLine("Invalid Input");
            }
            Console.ReadLine();

        }

         public static Note RestoreNoteFromText(){
            Console.Clear();
            Console.WriteLine("Restore note from textfile");
            Console.WriteLine("");
            
            Console.WriteLine("filename: ");
            String filename = Console.ReadLine();
            try{
                Note note = Note.LoadNoteFromFile(filename);
                return note;
            }
            catch{
                Console.WriteLine("Invalid File");
            }
            Console.ReadLine();
            return null;

        }

        static void ListAllNotes(List<Note> notes){
            int i = 0;
            foreach(Note note in notes){
                Console.Write(i);
                Console.Write(": ");
                Console.WriteLine(note.Title);
                i++;
            }
        }
    }
}