using System;
using VonRiddarn.School.AdvancedTasker.Commands;
using System.Linq;

internal class Program
{
	private static void Main(string[] args)
	{
		if(args.Length <= 0)
		{
			Console.WriteLine("AdvancedTasker: You must issue a command.\nUse command \"help\" for a list of all avalible commands.");
			Environment.Exit(0);	
		}
		
		FindAndRunCommand(args);
	}
	
	
	///<summary>Matches args[0] with a command type and calls the template method RunCommand for that command.</summary>
	///<remarks>args[0] is skipped and the rest of the array is sent through as args for the Execute method.</remarks>
	static void FindAndRunCommand(string[] args)
	{
		// Take the first end-user argument args[0] and turn it into
		// The full path of the command we want to execute. Finally saved as "typeName"
		string nameSpace = "VonRiddarn.School.AdvancedTasker.Commands.";
		string prefix = "Command_";
		string typeName = nameSpace + prefix + args[0];

		// Get the Type from path. This is a case insensitive search
		Type? type = Type.GetType(typeName, false, true);

		if (type == null)
		{
			Console.WriteLine("Command not found!\nUse command \"help\" for a list of avalible commands.");
			return;
		}
		
		// This code is only reachable if "type" is NOT null
		Command myObject = (Command)Activator.CreateInstance(type)!;

		myObject?.RunCommand(args[1..]);
	}
}