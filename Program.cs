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

/*Self-Reflections:

I believe the core system for commands is quite alright. 
It's expandable to infinity and doesn't require too much boiler code per new command.

Although I am proud of the utility "TaskContainer.GetContainerFromFilename" I still believe
that I could've found a more elegant solution for fetching and editing json objects.

The program has parts of recurring try-catch code that probably could be 
moved into some utility class or method instead, but I am unsure as of how to proceed.

All in all:

The project itself wasn't a hard task, the hard task was to make it expandable and somewhat abstract.
I believe I did a well enough job on expandability, but as far as abstraction goes I could do much better
as I am currently showing way too much data to exterior classes. 
Although all data is private or protected and showing only through properties
so it's not a fatal error, just an annoying one.

I expect to be fully done with the project 2022-09-26.

*/