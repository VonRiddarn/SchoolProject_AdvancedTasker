using System;

namespace VonRiddarn.School.AdvancedTasker.Commands;

abstract class Command
{

	// Using the template method pattern to ensure we call Execute and ShowHelp correctly.
	// Source: https://en.wikipedia.org/wiki/Template_method_pattern

	public void RunCommand(string[] args)
	{
		Console.WriteLine("TYOTOTOTOOT");
		if (args.Length > 0)
		{
			if (args[0] == "h" || args[0] == "help")
			{
				ShowHelp();
				return;
			}
		}
		
		Execute(args);
	}

	protected abstract void Execute(string[] args);

	protected abstract void ShowHelp();
}