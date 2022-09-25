# Advanced Tasker

Store, add and remove tasks in json files accessible through the built in commands.

## Commands

To run the uncompiled program, use "dotnet run" followed by command & arguments.

**Add a task to a list:**<br/>
add "description" 'list' 'due-in-days'<br/>
*EG: add "Walk the dog" houselist 365*<br/>

**Toggle task checkbox:**<br/>
check 'list' 'task-id'<br/>
*EG: check houselist 0*<br/>

**Show all tasks in a list:**<br/>
showlist 'list'<br/>
*EG: showlist houselist*<br/>

**Remove a task from a list:**<br/>
remove 'list' 'task-id'<br/>
*EG: remove houselist 0*<br/>

**Remove a list:**<br/>
remove 'list'<br/>
*EG: remove houselist*<br/>

**All commands have a helper text:**<br/>
Access it by adding "h" or "help" to the end of a command.<br/>
*EG: remove h*<br/>

## About this readme

It was made at 3am.<br/>
I know it ain't pretty.<br/>