using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.CMD;
class Command_Remove : Command
{
	public Command_Remove(string accessor) : base(accessor) { }

	// Task, List, Filter, DueDays
	public override void Execute(string[] args)
	{
		// Early return pattern
		if (args.Length > 2 || args.Length <= 0)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'remove' only takes 1 or 2 arguments.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return;
		}
		// /// //

		string fileName = args[0].ToLower();
		int taskId = 0;

		// If we want to remove the entire list
		if (args.Length == 1)
		{
			try
			{
				File.Delete($"UserLists/{fileName}.json");
			}
			catch
			{
				Console.Write("AdvancedTasker: ");
				Console.WriteLine($"Could not find or delete file {fileName}.json. Check your spelling and try again.");
			}

			return;
		}

		// This code can only be reached if a 2nd argument has been passed for the task ID.

		try // Make sure args[1] is of type int
		{
			taskId = int.Parse(args[1]);
		}
		catch // Else abort
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"{args[1]} is not a whole number. Cannot find task.");
			return;
		}

		// Get the container we want to add files to.
		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, false);
		
		// Remove task at index taskId and overwrite the json file.
		try
		{
			container.Tasks.RemoveAt(taskId);
			
			// Loop through the elements after the removed element and change their ID to match the new index.
			for(int i = taskId; i < container.Tasks.Count; i++)
			{
				container.Tasks[i].IndexId--;	
			}
		}
		catch
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"{taskId} is not a valid task index.");
			return;
		}
		
		container.SaveAsJson(fileName);
	}

	public override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Removes a task or list.");
		Console.WriteLine("Usage: remove <list> <task-id>");
		Console.WriteLine("List: The list you want remove / remove a task from.");
		Console.WriteLine("Task ID: The task you want to remove.");
		Console.WriteLine("Note: using remove <list> without adding a task id will remove the entire list.");
		Console.WriteLine();
	}
}