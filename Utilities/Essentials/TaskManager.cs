

using System.IO;
using VonRiddarn.School.AdvancedTasker;

static class TaskManager
{

	public static string[] GetAllUserListNames()
	{
		try
		{
			return Directory.GetFiles("UserLists/");
		}
		catch
		{
			return new string[0];
		}
	}

	public static Task[] GetAllTasksFromFile(string fileName)
	{
		fileName = fileName.ToLower();

		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, false);
		
		return container.Tasks.ToArray();
	}

	public static void AddTask(string taskName, string fileName, int dueInDays)
	{
		fileName = fileName.ToLower();

		// Get the container we want to add files to.
		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, true);

		// Create a new task utilizing the arguments passed from the end user in their parsed form.
		Task newTask = new Task(container.Tasks.Count, taskName, dueInDays);

		// Add the new task and overwrite the container json file.
		container.AddTask(newTask);
		SaveAsJson(fileName, container.Serialized());
	}

	public static void RemoveList(string fileName)
	{
		fileName = fileName.ToLower();

		try
		{
			File.Delete($"UserLists/{fileName}.json");
		}
		catch
		{
			// Console.Write("AdvancedTasker: ");
			// Console.WriteLine($"Could not find or delete file {fileName}.json. Check your spelling and try again.");
		}
	}

	public static void RemoveTask(string fileName, int taskId)
	{
		fileName = fileName.ToLower();

		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, false);

		// Remove task at index taskId and overwrite the json file.
		try
		{
			container.Tasks.RemoveAt(taskId);

			// Loop through the elements after the removed element and change their ID to match the new index.
			for (int i = taskId; i < container.Tasks.Count; i++)
			{
				container.Tasks[i].IndexId--;
			}
		}
		catch
		{
			// Console.Write("AdvancedTasker: ");
			// Console.WriteLine($"{taskId} is not a valid task index.");
			return;
		}

		TaskManager.SaveAsJson(fileName, container.Serialized());
	}

	public static void ToggleTask(string fileName, int taskId)
	{
		fileName = fileName.ToLower();

		TaskContainer container = TaskContainer.GetContainerFromFilename(fileName, false);


		if (container.Tasks.Count <= 0)
		{
			// Console.Write("AdvancedTasker: ");
			// Console.WriteLine($"There are no tasks in the list {fileName}.");
			return;
		}

		try
		{
			container.Tasks[taskId].ToggleIsDone();
		}
		catch
		{
			//Console.Write("AdvancedTasker: ");
			//Console.WriteLine($"{taskId} is not a valid task index.");
			return;
		}

		SaveAsJson(fileName, container.Serialized());
	}

	public static void SaveAsJson(string fileName, string jsonString)
	{
		fileName = fileName.ToLower();

		try
		{
			File.WriteAllText($"UserLists/{fileName}.json", jsonString);
		}
		catch
		{
			// Console.Write("AdvancedTasker: ");
			// Console.WriteLine($"Error writing to file {filename}.json");
			return;
		}
	}

}