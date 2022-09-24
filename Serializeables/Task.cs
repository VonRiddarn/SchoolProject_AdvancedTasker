using System;
using System.Text.Json.Serialization;

namespace VonRiddarn.School.AdvancedTasker;
class Task
{
	int _indexId = 0;
	public int IndexId { get { return _indexId; } set { _indexId = value; } }
	
	string _description = "Task";
	public string Description { get { return _description; } set { _description = value; } }

	bool _isDone = false;
	public bool IsDone { get { return _isDone; } set { _isDone = value; } }

	DateTime _creationDate = DateTime.Now;
	public DateTime CreationDate { get { return _creationDate; } set { _creationDate = value; } }

	DateTime _dueDate = DateTime.Now;
	public DateTime DueDate { get { return _dueDate; } set { _dueDate = value; } }

	[JsonIgnore]
	public int DaysLeft => (_dueDate.Date - DateTime.Now.Date).Days;

	// Pesky empty constructor for the json deserializer
	public Task() { }

	public Task(int indexId, string description, int dueInDays)
	{
		_indexId = indexId;
		_description = description;
		_creationDate = DateTime.Now;
		_dueDate = _creationDate.AddDays(dueInDays);
	}

	public string GetFormatedString()
	{
		string checkMark = _isDone ? "X" : " ";

		return $"[{checkMark}] | Due in {DaysLeft} days | {_description}";
	}

	public void SetIsDone(bool isDone) => _isDone = isDone;
	public void ToggleIsDone() => _isDone = !_isDone;

}