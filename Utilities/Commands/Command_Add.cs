using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.Commands;
class Command_Add : Command
{

	// Task, List, DueDays
	protected override void Execute(string[] args)
	{
		int dueInDays = 0;

		if (TryEarlyReturn(args.Length))
			return;

		try
		{
			dueInDays = int.Parse(args[2]);
		}
		catch
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"{args[2]} is not a whole number. Cannot add task.");
			return;
		}

		TaskManager.AddTask(args[0], args[1], dueInDays);
	}

	protected override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Adds a task to a list.");
		Console.WriteLine("Usage: add \"description\" <list> <due-in-days>");
		Console.WriteLine("Description: A task description, such as \"Walk the dog\".");
		Console.WriteLine("List: The tasklist to save this task in, such as \"work\" or \"home\".");
		Console.WriteLine("Due in days: How many days from now the task is due.");
		Console.WriteLine();
	}

	// Custom methods

	bool TryEarlyReturn(int argsCount)
	{
		if (argsCount != 3)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'add' only takes 4 arguments.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return true;
		}

		return false;
	}
}