public class PlayerStateMachine
{
    private State _currentState;

    private Player _player;
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
        _currentState?.Exit();
        _currentState = newState;
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
