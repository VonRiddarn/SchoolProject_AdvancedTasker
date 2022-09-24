using System;
using VonRiddarn.School.AdvancedTasker.CMD;
using VonRiddarn.School.AdvancedTasker;


internal class Program
{
	private static void Main(string[] args)
	{
		// Use the run command : "dotnet run add something list 0"
		// You could technically run the command in other ways as well, the important thing is that the 3rd argument is the same each time
		
		CommandHub.FindAndExecuteFromArgumentArray(args);
	}
}