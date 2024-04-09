public class PlayerStateMachine
{
    private State _currentState;
    private State _previousState;

    private Player _player;
    public State PreviousState => _previousState;
    public Player Player => _player;

    public PlayerStateMachine(Player player)
    {
        _player = player;
    }

    public void Start(State startingState)
    {
        _currentState = startingState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        _previousState = _currentState;
        _currentState?.Exit();
        _currentState = newState;
        _currentState.Enter();
    }

    public void GoToPreviousState()
    {
        if (_previousState == null) return;

        _currentState.Exit();
        _currentState = _previousState;
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState?.Update();
    }

    public void FixedUpdate()
    {
        _currentState?.FixedUpdate();
    }
}
