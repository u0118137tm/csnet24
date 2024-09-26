using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;

namespace classlib
{
    public class Note
    {
        public String Title { get; set; }
        public String Text { get; set; }
        int _priority;
        public int Priority { 
            get{
                return _priority;
            } 
            set{
                _priority = value switch {
                    <=0 => 0,
                    >0 and <=10 => value,
                    >10 => 10
                }; 
            }
        }

        public List<String> Tags { get; set; } = new List<string>();

        static int currentId = 0;
        int _id;

        public int Id { get; init;}

        public Note(String title, String text, int priority = 5)
        {
            Title = title;
            Text = text;
            Priority = priority;

            Id = currentId;
            currentId++;

        }
        

        public (String, int) GetTitlePriority(){
            return (Title, Priority);
        }

        public void GetTitleText(out String title, out String text){
            title = Title;
            text = Text;
        }

        public String GetImportance(){
            return Priority switch{
                <=5 => "unimportant",
                >5 and <8 => "a little important",
                >8 => "very important"
            };
        }

        public int GetNoteLength(){
            return Text.Length;
        }

        public void AddTags(String[] taglist){
            foreach(String tag in taglist){
                Tags.Add(tag);
            }
        }

        public static String GetJSON(Note note){
            return JsonConvert.SerializeObject(note);
        }

        public static void SaveNoteToText(Note note, String filename){
            File.WriteAllText(filename,Note.GetJSON(note));
        }

        public static Note? LoadNoteFromFile(String filename){
            Note? note;
            try{
                note = JsonConvert.DeserializeObject<Note>(File.ReadAllText(filename));
                return note;
            }
            catch{
                return null;
            }

        }





    }
}