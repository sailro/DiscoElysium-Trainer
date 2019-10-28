# DiscoElysium-Trainer

This is an attempt -for educational purposes only- to alter a Unity game at runtime without patching the binaries (so without using [Cecil](https://github.com/jbevain/cecil) nor [Reflexil](https://github.com/sailro/reflexil)).
To achieve that, we use [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector), able to:
- dynamically attach to a process
- call suitable methods to load an assembly in the Game AppDomain
- call managed methods in the assembly.

So we have a very simple trainer for the excellent [Disco Elysium](https://store.steampowered.com/app/632470) game. 

How to use the trainer:
- Start a new game or load any savegame
- Go back to the windows desktop
- Run `load.bat` to inject the trainer into the process (you do not need to copy files in a specific location).
- Use keypad `/` `*` to remove/add 100 Réal
- Use keypad `8` `9` to remove/add 1 Skill point
- Use keypad `5` `6` to remove/add 10 XPs
- Use keypad `2` `3` to decrease/increase cap for all abilities.
- Run unload.bat to disable the trainer.

You can compile everything or simply use the [demo release](https://github.com/sailro/DiscoElysium-Trainer/releases).

Have fun !
