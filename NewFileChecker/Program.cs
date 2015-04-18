using System;
using System.IO;
using System.Security.Permissions;
using System.Collections.Generic;

public class Watcher
{

    public static string CurrentDir;
    public static string FileType;

    public static void Main()
    {

        Run();
    }

    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]

    public static void Run()
    {        
        Console.WriteLine("Enter path to monitor: ");
        CurrentDir = Console.ReadLine();

        Console.WriteLine("\nWhich file type should I look for?\npress Enter for all file types: ");
        FileType = Console.ReadLine();

        if (FileType != "")
        {
            FileType = "*." + FileType;
        }
        else 
        {
            FileType = "*";
        }

        FileSystemWatcher watcher = new FileSystemWatcher(CurrentDir, FileType);
         

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