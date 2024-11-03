1. source: https://github.com/sschmid/Match-One
2. properties: https://github.com/sschmid/Match-One/blob/main/Jenny.properties
3. rider tools: Settings(ctr+alt+s) -> Tools -> External Tools -> +(plus) ->
		Name: Jenny_1.14 (version)
		_Windows_ (description/video)
		Program: $SolutionDir$/../../Jenny/Jenny-Gen.bat - advice from the description, where ../ folder step out
				 $SolutionDir$/Assets/Jenny/Jenny-Gen.bat - advice from the video
				 $SolutionDir$/../jenny/Jenny-Gen.bat - for my project structure
				 D:\Unity\ECS Survivors\jenny\Jenny-Gen.bat - use a specific path
		Working directory: $SolutionDir$….\Jenny - advice from the description
						   $SolutionDir$\Assets\Jenny\ - advice from the video
						   $SolutionDir$/../jenny - for my project structure
						   D:\Unity\ECS Survivors\jenny - use a specific path
		_MacOS_  (advice from the description)
		Program: sh
		Arguments: $SolutionDir$/../../Jenny/Jenny-Gen
		Working Directory: $SolutionDir$/../../Jenny
		-> Ok -> Save(close)
		Settings(ctr+alt+s) -> Keymap -> External Tool -> Add Keyboard Shortcut -> Ctrl+Shift+G -> Ok -> Save(close)
		Run the .bat to check the installation process: ctrl+shift+g
