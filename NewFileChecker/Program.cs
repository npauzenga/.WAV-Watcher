using System;
using System.IO;
using System.Security.Permissions;
using System.Collections.Generic;

public class Watcher
{

    public static string CurrentDir;

    public static void Main()
    {

        Run();
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

    public static void Run()
    {        
        Console.WriteLine("Enter Path: ");
        CurrentDir = Console.ReadLine();
 
        FileSystemWatcher watcher = new FileSystemWatcher(CurrentDir, "*.wav");
         

        watcher.IncludeSubdirectories = true;

        /* Watch for changes in LastAccess and LastWrite times, and
           the renaming of files or directories. */

        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;

        // Add event handlers.
        watcher.Created += new FileSystemEventHandler(OnChanged);
      

        // Begin watching.
        watcher.EnableRaisingEvents = true;

        // Wait for the user to quit the program.
        Console.WriteLine("Newly created items will appear below. Press \'q\' to quit. \n" + 
                        "Press \'s\' to show a list of items created give a start time.");

        while (Console.Read() != 'q');
       
    }

   
    private static void OnChanged(object source, FileSystemEventArgs e)
    {   
        Console.WriteLine("File: " + e.FullPath);      
    }
}