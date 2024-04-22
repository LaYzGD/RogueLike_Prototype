using System;

public class CombatState : State
{
    private CombatStateMachine _combatStateMachine;
    private Combat _combat;
    private Inputs _inputs;
    private Action<bool> _toggleHorizontalCombat;

    protected CombatStateMachine CombatStateMachine => _combatStateMachine;
    protected Combat Combat => _combat;
    protected Inputs Inputs => _inputs;
    protected Action<bool> ToggleHorizontalCombat => _toggleHorizontalCombat;

    public CombatState(CombatStateMachine combatStateMachine, Action<bool> toggleHorizontalCombat) 
    {
        _combatStateMachine = combatStateMachine;
        _combat = _combatStateMachine.Combat;
        _inputs = _combat.Inputs;
        _toggleHorizontalCombat = toggleHorizontalCombat;
    }
}
