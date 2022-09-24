namespace VonRiddarn.School.AdvancedTasker.CMD;

abstract class Command
{
	protected string _accessor = "command";
	public string Accessor { get { return _accessor; } }
	
	public abstract void Execute(string[] args);
	
	public abstract void ShowHelp();
	
	public Command(string accessor) => _accessor = accessor;
}