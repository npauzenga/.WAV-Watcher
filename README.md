# .WAV-Watcher

A simple program to allow users to monitor a specified directory for new or modified files of a given type. Lists files
in a console window.

Designed to be used in an video game audio production environment with Perforce where audio and 
associated files are created often and can be tough to manually track. This will give the user the ability
to see which files they've modified or created since the app has started (intended to be executed in a batch file wtih P4v).

Planned features:
- Perforce Integration! Automatically add files *of speficied types* to a new changelist (basically a more flexible
version of Perforce's Automatically Mark Files for Add function), Reset file display output on submit

