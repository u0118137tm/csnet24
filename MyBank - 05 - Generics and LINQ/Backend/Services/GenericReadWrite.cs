using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class GenericReadWrite
    {
        public static Boolean Save<T>(String FileName, ObservableCollection<T> objlist){

            using(StreamWriter outputFile = new StreamWriter(FileName)){
                foreach(T i in objlist){   
                    String jsonString = JsonSerializer.Serialize(i);
                    Console.WriteLine(jsonString);
                    outputFile.WriteLine(jsonString);
                }
            }

            
            return true;
        }

        public static async Task<ObservableCollection<T>> ReadAsync<T>(String FileName){
            ObservableCollection<T> CurrentAccountListFromFile = await Task<ObservableCollection<T>>.Run(() => Read<T>(FileName));
            await Task.Delay(5000);
            return CurrentAccountListFromFile;
        }

        public static ObservableCollection<T> Read<T>(String FileName){

            String line;  
            ObservableCollection<T> ReadList = new ObservableCollection<T>();
            System.IO.StreamReader file = new System.IO.StreamReader(FileName);  
            while((line = file.ReadLine()) != null)  
            {  
                try{
                    T t = JsonSerializer.Deserialize<T>(line.Replace("\n", "").Replace("\r", ""));
                    ReadList.Add(t);
                }
                catch(Exception e){
                    Console.WriteLine(e);
                }
                Console.WriteLine(line);
            }  
  
            file.Close();  

            return ReadList;
        }
    }
}