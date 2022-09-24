using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker.CMD;
class Command_ShowList : Command
{
	public Command_ShowList(string accessor) : base(accessor) { }

	// Task, List, Filter, DueDays
	public override void Execute(string[] args)
	{
		// Early return pattern
		if (args.Length != 1)
		{
			Console.WriteLine();
			Console.Write("AdvancedTasker: ");
			Console.WriteLine("The command 'showlist' only takes 1 argument.");
			Console.WriteLine("Type '<command> h' or '<command> help' for more info.");
			Console.WriteLine();
			return;
		}
		// /// //

		string fileName = args[0].ToLower();
		
		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, false);
		
		if(container.Tasks.Count <= 0)
		{
			Console.Write("AdvancedTasker: ");
			Console.WriteLine($"There are no tasks in the list {fileName}.");
			return;
		}
		
		Console.WriteLine($"Listing tasks from \"{fileName}\"");
		for(int i = 0; i < container.Tasks.Count; i++)
		{
			Console.WriteLine(container.Tasks[i].GetFormatedString());
		}
		
	}

	public override void ShowHelp()
	{
		Console.WriteLine();
		Console.WriteLine("Shows all tasks saved in a list.");
		Console.WriteLine("Usage: showlist <list>");
		Console.WriteLine("List: The list you want to show.");
		Console.WriteLine();
	}
}