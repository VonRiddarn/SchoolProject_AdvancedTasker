using System;

namespace VonRiddarn.School.AdvancedTasker.Commands;

class Command_Help : Command
{
	protected override void Execute(string[] args)
	{
		Console.WriteLine();
		Console.WriteLine("----- Commands -----");
		Console.WriteLine("add \"<description>\" <list> <due-in-days>");
		Console.WriteLine("> Add a task to <list> with the duedate <due-in-days>.");
		Console.WriteLine();
		Console.WriteLine("remove <list> <task-id>");
		Console.WriteLine("> Remove task <task-id> from list <list>.");
		Console.WriteLine();
		Console.WriteLine("remove <list>");
		Console.WriteLine("> Remove list <list> and all tasks associated with it.");
		Console.WriteLine();
		Console.WriteLine("check <list> <task-id>");
		Console.WriteLine("> Toggle the checkbox of task <task-id> in list <list>.");
		Console.WriteLine();
		Console.WriteLine("showlist <list>");
		Console.WriteLine("> Show all tasks within list <list>.");
		Console.WriteLine();
	}

	protected override void ShowHelp() => Execute(new string[0]);
}