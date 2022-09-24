using System;

namespace VonRiddarn.School.AdvancedTasker;
class Task
{
	/*Guid _id = Guid.Empty;
	public Guid ID { get { return _id; } }*/
	
	string _description = "Task";
	public string Description { get { return _description; } set {_description = value; }}

	string _filter = string.Empty;
	public string Filter { get { return _filter; } set {_filter = value; }}

	bool _isDone = false;
	public bool IsDone { get { return _isDone; } set {_isDone = value; }}

	DateTime _creationDate = DateTime.Now;
	DateTime _dueDate = DateTime.Now;

	public Task() {}
	
	public Task(string description, string filter, int dueInDays)
	{
		_description = description;
		_filter = filter;
		_creationDate = DateTime.Now;
		_dueDate = _creationDate.AddDays(dueInDays);
		//_id = Guid.NewGuid();
	}

	public string GetFormatedString()
	{
		string checkMark = _isDone ? "X" : " ";
		int daysLeft = (_dueDate.Date - DateTime.Now.Date).Days;

		return $"[{checkMark}] | {_filter} | Due in {daysLeft} days | {_description}";
	}

	public void SetIsDone(bool isDone) => _isDone = isDone;
	public void ToggleIsDone() => _isDone = !_isDone;
	
}