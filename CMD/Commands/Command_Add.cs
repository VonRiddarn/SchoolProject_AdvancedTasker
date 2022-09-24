using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.CMD;
class Command_Add : Command
{
	public Command_Add(string accessor) : base(accessor) { }


	// Task, List, Filter, DueDays
	public override void Execute(string[] args)
	{
		// Early return pattern
		if (args.Length != 3)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'add' only takes 4 arguments.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return;
		}
		// /// //
		
		string fileName = args[1].ToLower();
		int dueInDays = 0;
		
		try // Make sure args[2] is of type int
		{
			dueInDays = int.Parse(args[2]);
		}
		catch // Else abort
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"{args[2]} is not a whole number. Cannot add task.");
			return;
		}
		
		// Get the container we want to add files to.
		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName);
		
		// Create a new task utilizing the arguments passed from the end user in their parsed form.
		Task newTask = new Task(container.Tasks.Count, args[0], dueInDays);
		
		// Add the new task and overwrite the container json file.
		container.AddTask(newTask);
		container.SaveAsJson(fileName);
	}

	public override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Adds a task to a list.");
		Console.WriteLine("Usage: add \"description\" <list> <due-in-days>");
		Console.WriteLine("Description: A task description, such as \"Walk the dog\".");
		Console.WriteLine("List: The tasklist to save this task in, such as \"work\" or \"home\".");
		Console.WriteLine("Due in days: How many days from now the task is due.");
		Console.WriteLine();
	}
}