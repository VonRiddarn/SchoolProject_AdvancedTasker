using System;
using VonRiddarn.School.AdvancedTasker.CMD;
using VonRiddarn.School.AdvancedTasker;


internal class Program
{
	private static void Main(string[] args)
	{
		// Run the arguments throguh the commandhub and look for a matching command.
		// All the commands are stored under: CMD/Commands
		// The root command class is stored under: CMD/Essentials/Command.cs
		CommandHub.FindAndExecuteFromArgumentArray(args);
	}
}