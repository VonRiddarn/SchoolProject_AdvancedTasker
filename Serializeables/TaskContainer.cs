using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker;
class TaskContainer
{
	string _name = "Task List";
	public string Name { get { return _name; } set { _name = value; } }

	List<Task> _tasks = new List<Task>();
	public List<Task> Tasks { get { return _tasks; } set { _tasks = value; } }

	public TaskContainer(string name) => _name = name;

	///<summary>The JSON string representation of this object</summary>
	public string Serialized() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

	public void AddTask(Task task) => Tasks.Add(task);


	// Static utilities
	public static TaskContainer GetContainerFromFilename(string fileName, bool createFileOnError)
	{
		TaskContainer? container = null;

		try
		{
			string containerJson = File.ReadAllText($"UserLists/{fileName}.json");
			container = JsonSerializer.Deserialize<TaskContainer>(containerJson);
		}
		catch
		{
			container = new TaskContainer(fileName);

			if (createFileOnError)
			{
				Console.WriteLine($"Could not cretae object from file {fileName}.json creating file...");
				File.Create($"UserLists/{fileName}.json").Close(); // Must put close after so that File.WriteAllText can use the stream.
			}
		}

		return container!;
	}

}