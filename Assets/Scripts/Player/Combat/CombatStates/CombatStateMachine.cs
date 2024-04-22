public class CombatStateMachine : StateMachine
{
    private Combat _combat;
    public Combat Combat => _combat;

    public CombatStateMachine(Combat combat)
    {
        _combat = combat;
    }
}
