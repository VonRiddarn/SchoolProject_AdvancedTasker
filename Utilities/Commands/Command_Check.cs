using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.Commands;
class Command_Check : Command
{

	// Task, List, Filter, DueDays
	protected override void Execute(string[] args)
	{
		string fileName = args[0].ToLower();
		int taskId = 0;

		if (TryEarlyReturn(args.Length))
			return;

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
		
		
		TaskManager.ToggleTask(fileName, taskId);
	}

	protected override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Toggles completion of a task in a list.");
		Console.WriteLine("Usage: check <list> <task-id>");
		Console.WriteLine("List: The list you want to edit.");
		Console.WriteLine("Task ID: The task ID you want to toggle.");
		Console.WriteLine();
	}


	// Custom methods

	bool TryEarlyReturn(int argsCount)
	{
		if (argsCount != 2)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'check' only takes 2 arguments.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return true;
		}

		return false;
	}

}