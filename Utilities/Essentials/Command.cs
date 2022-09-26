namespace VonRiddarn.School.AdvancedTasker.Commands;

abstract class Command
{

	// Using the template method pattern to ensure we call Execute and ShowHelp correctly.
	// Source: https://en.wikipedia.org/wiki/Template_method_pattern

	
	///<summary>Template method making an argument check and calling Execute or ShowHelp
	/// depending on the end-users intentions.</summary>
	public void RunCommand(string[] args)
	{
		if (args.Length > 0)
		{
			if (args[0] == "h" || args[0] == "help")
			{
				// We could add fancy graphical stuff here.
				ShowHelp();
				return;
			}
		}
		
		Execute(args);
	}

	protected abstract void Execute(string[] args);
	
	protected abstract void ShowHelp();
	
	// Later on we might want to let ShowHelp return a string in order to
	// abstract away the need to run the program in the console.
}