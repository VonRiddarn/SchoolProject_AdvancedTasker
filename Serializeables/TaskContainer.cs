using System;
using System.Collections.Generic;
using System.Text.Json;

namespace VonRiddarn.School.AdvancedTasker;
class TaskContainer
{
	string _name = "Task List";
	public string Name { get { return _name; } set { _name = value; } }

	List<Task> _tasks = new List<Task>();
	public List<Task> Tasks { get { return _tasks; } set { _tasks = value; } }
	
	public TaskContainer(string name) => _name = name;

	public string SerializeObject() => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });

	public void AddTask(Task task) => Tasks.Add(task);

}