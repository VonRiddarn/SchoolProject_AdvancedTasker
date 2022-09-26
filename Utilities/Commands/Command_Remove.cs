using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.Commands;
class Command_Remove : Command
{

	// List, Task
	protected override void Execute(string[] args)
	{
		if (TryEarlyReturn(args.Length))
			return;

		if (args.Length == 2)
			RemoveTask(args);
		else
			RemoveTask(args);
	}

	protected override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Removes a task or list.");
		Console.WriteLine("Usage: remove <list> <task-id>");
		Console.WriteLine("List: The list you want remove / remove a task from.");
		Console.WriteLine("Task ID: The task you want to remove.");
		Console.WriteLine("Note: using remove <list> without adding a task id will remove the entire list.");
		Console.WriteLine();
	}

	// Custom methods

	bool TryEarlyReturn(int argsCount)
	{
		if (argsCount > 2 || argsCount <= 0)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'remove' only takes 1 or 2 arguments.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return true;
		}
		
		return false;
	}

	void RemoveTask(string[] args)
	{
		int taskId = 0;

		try
		{
			taskId = int.Parse(args[1]);
		}
		catch
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"{args[1]} is not a whole number. Cannot find task.");
			return;
		}
		
		TaskManager.RemoveTask(args[0], taskId);
		
	}

	void RemoveList(string[] args)
	{
		TaskManager.RemoveList(args[0]);	
	}

}