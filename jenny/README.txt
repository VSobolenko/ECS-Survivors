1. source: https://github.com/sschmid/Match-One
2. properties: https://github.com/sschmid/Match-One/blob/main/Jenny.properties
3. rider tools: Settings(ctr+alt+s) -> Tools -> External Tools -> +(plus) ->
	Name: Jenny_1.14 (version)
	_Windows_ (description/video)
		Program: $SolutionDir$/../../Jenny/Jenny-Gen.bat - advice from the description, where ../ folder step out
				 $SolutionDir$/Assets/Jenny/Jenny-Gen.bat - advice from the video
			 	 $SolutionDir$/../jenny/Jenny-Gen.bat - for my project structure
			 	 D:\Unity\ECS Survivors\jenny\Jenny-Gen.bat - use a specific path
		Working directory: 	$SolutionDir$….\Jenny - advice from the description
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
4. Microsoft .Net 6.0(Win/Mac) : https://dotnet.microsoft.com/en-us/download/dotnet/6.0
5. create code snippets: Settings(ctr+alt+s) -> Editor -> Live Templates -> Unity/C# -> +(plus) ->
	-----------------------------------------exec / system-----------------------------------------
	Shortcut: exec / system
	Description: Entitas - IExecuteSystem
	Options: (all)
	Availability: Unity projects
	Use in: Generation
	Code: 
public class $name$ : IExecuteSystem
{
    private readonly IGroup<GameEntity> $_entities$;

    public $name$(GameContext game)
    {
        $_entities$ = game.GetGroup(GameMatcher.AllOf(GameMatcher.$matcher$));
    }

    public void Execute()
    {
        foreach (GameEntity $entity$ in $_entities$)
        {
            $END$
        }
    }
}
	-> +(plus) ->
	-----------------------------------------react-----------------------------------------
	Shortcut: react
	Description: Entitas - ReactiveSystem
	Options: (all)
	Availability: Unity projects
	Use in: Generation
	Code: 
public class $name$ : ReactiveSystem<$context$Entity>
{
	public $name$($context$Context $contextVar$) : base($contextVar$)
	{
	}

	protected override ICollector<$context$Entity> GetTrigger(IContext<$context$Entity> context) =>
		context.CreateCollector($context$Matcher.$matcher$.$action$);

	protected override bool Filter($context$Entity $entity$) => $filter$;

	protected override void Execute(List<$context$Entity> $entities$)
	{
		foreach ($context$Entity $entity$ in $entities$)
		{
			$END$
		}
	}
}
	-> +(plus) ->
	-----------------------------------------cleanup-----------------------------------------
	Shortcut: cleanup
	Description: Entitas - ICleanupSystem
	Options: (all)
	Availability: Unity projects
	Use in: Generation
	Code: 
public class $name$ : ICleanupSystem
{
	private readonly IGroup<$context$Entity> _$_entities$;
	private readonly List<$context$Entity> _buffer = new ($bufferCount$);

	public $name$($context$Context $contextParameter$)
	{
		_$_entities$ = $contextParameter$.GetGroup($context$Matcher.AllOf($matcher$$END$));
	}

	public void Cleanup()
	{
		foreach ($context$Entity $entity$ in _$_entities$.GetEntities(_buffer))
		{
			$END$
		}
	}
}
	-> +(plus) ->
	-----------------------------------------feature-----------------------------------------
	Shortcut: feature
	Description: Entitas - Feature
	Options: (all)
	Availability: Unity projects
	Use in: Generation
	Code: 
public sealed class $name$Feature : Feature
{
	public $name$Feature(ISystemFactory systems)
	{
		Add(systems.Create<$system$>()); $END$
	}
}
	-> Ok -> Save(close)
	
	