using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.Commands;
class Command_ShowList : Command
{
	
	// Task, List, Filter, DueDays
	protected override void Execute(string[] args)
	{
		if(args.Length == 0)
			ShowLists();
		else if(args.Length == 1)
			ShowTasksInList(args);
		else
			Console.WriteLine("Error: showlist only takes 0 or 1 argument.");
			

	}

	protected override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Shows all tasks saved in a list.");
		Console.WriteLine("Usage: showlist <list>");
		Console.WriteLine("List: The list you want to show.");
		Console.WriteLine();
	}
	
	// Custom methods
	
	void ShowLists()
	{
		string[] lists = TaskManager.GetAllUserLists();
		
		foreach(string listName in lists)
		{
			// Trim away "UserLists/" and ".json" from file name.
			string newName = listName;
			int splitPoint = newName.IndexOf('/')+1;
			newName = newName.Substring(splitPoint);
			splitPoint = newName.IndexOf('.');
			newName = newName.Remove(splitPoint);
			
			Console.WriteLine(newName);
		}
	}
	
	void ShowTasksInList(string[] args)
	{
		Task[] tasks = TaskManager.GetAllTasksFromFile(args[0]);
		
		if(tasks.Length <= 0)
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"No list of name {args[0]} found.");
			return;
		}
		
		for(int i = 0; i < tasks.Length; i++)
		{
			Console.WriteLine(tasks[i].GetFormatedString());
		}
		
	}
	
}