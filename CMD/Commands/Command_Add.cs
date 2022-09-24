using System;
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
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'add' only takes 4 arguments. Type '<command> h' or '<command> help' for more info.");
			return;
		}

		string fileName = args[1].ToLower();
		TaskContainer container = null;

		try
		{
			string containerJson = File.ReadAllText($"UserLists/{fileName}.json");
			Console.WriteLine("FILE: " + containerJson);
			container = JsonSerializer.Deserialize<TaskContainer>(containerJson);
			Console.WriteLine("OBJ: " + container.SerializeObject());
		}
		catch
		{
			Console.WriteLine("Path not found. Creating new file...");
		}

		if (container == null)
			container = new TaskContainer(fileName);

		try
		{
			container.AddTask(new Task(args[0], args[1], int.Parse(args[2])));

			File.WriteAllText($"UserLists/{fileName}.json", container.SerializeObject());
		}
		catch
		{
			Console.WriteLine("ERROR: Something went wrong writing to file. Check your input and try again.");
			return;
		}
	}

	public override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Usage: add <description> <list> <due-in-days>");
		Console.WriteLine("Description: A task description, such as 'Walk the dog'.");
		Console.WriteLine("List: The tasklist to save this task in, such as 'work' or 'home'.");
		Console.WriteLine("Due in days: How many days from now the task is due.");
		Console.WriteLine();
	}
}