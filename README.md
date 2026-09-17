# DungeonSettlersSaveEditor

This code allows you to edit saves for the game DungeonSettlers.
It is a Windows Forms application so it will only run on a Windows Machine.

It can currently only edit the inscriptions applied to characters, but I will expand the functionality. The Editor manually edits learned skills and skill points when Applying/Removing those traits. I haven't extensively tested other traits yet, but the tests I have performed went well. That being said, expect bugs. I will try to fix reported bugs but I might just not be able to do so with just save editing. 

Known issues:
 - Removing an inscription that grants a skill, removes the skil even if the character would have had the skill without the inscription.
 - When removing a inscription that grants a skill, the program will try to remove 5 skill points as well. If you have less than 5 skill points you only lose whatever you had, as the game doesn't like negative skill points.
 - Currently I'm only using the English KeyNames, so the English Default names will show up for characters which aren't renamed regardless of what language your game is set to.
 
Planned features:
 - Editing Clan Gold
 - Editing inventory
 - Editing other traits 
 - Changing difficulty (if technically possible)
 - Changing ironman status (if technically possible)
 - Having a GUI that doesn't make your eyes bleed. (It is really barebones now, see screenshot below)
 - Actual Error Handling

I will probably maintain this code until mods come out.

Usage: 
- Click "Load Save"
- Click the Character you want to edit.
- Click the inscription you want to Add/Remove
- Click the corresponding button
- Press "Save Changes" when you're done.

New saves are written in the same folder as the save you edited. It does NOT overwrite the old save unless you use the same name.
"_Edited" is appended to the original save name by default to prevent overwriting accidents.

<img width="1192" height="690" alt="image" src="https://github.com/user-attachments/assets/2edc762b-391a-4d99-ba2f-d4131f13ae56" />

Special thanks to the legends maintaining https://dungeonsettlers.wiki/ for freely providing json files mined from the game, which I used liberally.
