# DungeonSettlersSaveEditor

This code allows you to edit saves for the game DungeonSettlers.
It is a Windows Forms application so it will only run on a Windows Machine.

It can currently only edit inscriptions, but I will expand the functionality.

Known issues:
 - Removing an inscription that grants a skill, removes the skil even if the character would have had the skill without the inscription.
 - When removing a inscription that grants a skill, the program will try to remove 5 skill points as well. If you have less than 5 skill points you only lose whatever you had, as the game doesn't like negative skill points.
 - Currently I'm only using the English KeyNames, so the English Default names will show up for characters which aren't renamed regardless of what language your game is set to.
 
Planned features:
 - Editing Clan Gold
 - Editing inventory
 - Changing difficulty (if technically possible)
 - Changing ironman status (if technically possible)

I will maintain this code until mods come out.