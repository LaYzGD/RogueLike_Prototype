public abstract class StateMachine
{
    protected State CurrentState { get; set; }

    public virtual void ChangeState(State newState)
    {
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public virtual void FixedUpdate()
    {
        CurrentState?.FixedUpdate();
    }

    public virtual void Start(State startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public virtual void Update()
    {
        CurrentState?.Update();
    }
}
