using System;
using System.Linq;


namespace VonRiddarn.School.AdvancedTasker.CMD;
static class CommandHub
{

	public static Command[] _commands =
	{
		new Command_Add("add"),
		new Command_Remove("remove")
	};

	public static void FindAndExecuteFromArgumentArray(string[] args)
	{
		bool foundCommand = false;

		// Split the command name from the args array and store separetly
		string commandName = args[0].ToLower();

		// Replace the args array with a new array containing only the arguments.
		args = args.Skip(1).ToArray();

		for (int i = 0; i < _commands.Length; i++)
		{
			if (_commands[i].Accessor.ToLower() != commandName)
				continue;


			// This code can only be reached if we have a command name match.

			foundCommand = true;

			if (args.Length > 0)
			{
				if (args[0].ToLower() == "h" && args[0].ToLower() == "help")
				{
					_commands[i].ShowHelp();
					return;
				}
			}
			
			_commands[i].Execute(args);
		}

		if (foundCommand)
			return;

		// This code can only be reached if we did not find a command in the for-loop.
		// TODO: If needed, turn messages from Advanced Tasker into a utility class.
		Console.Write("AdvancedTasker: ");
		Console.WriteLine($"Could not find command of name '{commandName}' did you spell it correctly?");
	}
}