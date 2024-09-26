
using classlib;
using console;

List<Note> Notes = new ();

int choise = -1;


Notes.Add(new Note("Note 1", "Text in note 1", 10));
Notes.Add(new Note("Note 2", "Text in note 2, and some other text", 1));
Notes.Add(new Note("Note 3", "Note 3 text"));

do{
    
    choise = Menu.ShowMainMenu();

    switch(choise){
        case 1: 
            Notes.Add(Menu.CreateNewNote());
            break;
        case 2: 
            Menu.ShowAllNotes(Notes);
            break;
        case 3: 
            Menu.GetNoteTitlePriority(Notes);
            break;
        case 4: 
            Menu.GetNoteTitleText(Notes);
            break;
        case 5: 
            Menu.GetNoteImportance(Notes);
            break;
        case 6: 
            Menu.GetNoteLength(Notes);
            break;
        case 7: 
            Menu.AddTags(Notes);
            break;
        case 8: 
            Menu.GetAllTags(Notes);
            break;
        case 9: 
            Menu.SaveNoteToText(Notes);
            break;
        case 10: 
            Note note = Menu.RestoreNoteFromText();
            if(note != null){
                Notes.Add(note);
                Console.WriteLine("Note restored");
                Console.ReadLine();
            }
            break;


    }

}while(choise != 0);



