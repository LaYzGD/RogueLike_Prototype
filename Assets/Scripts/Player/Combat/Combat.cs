using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CombatData _data;
    [SerializeField] private CharacterAnimator _weaponAnimator;

    private Inputs _inputs;

    private bool _isInHorizontalCombat;

    public Inputs Inputs => _inputs;
    public CharacterAnimator WeaponAnimator => _weaponAnimator;
    public bool IsInHorizontalCombat => _isInHorizontalCombat;

    private CombatStateMachine _combatStateMachine;
    public CombatIdleState CombatIdleState { get; private set; }
    public CombatHorizontalState CombatHorizontalState { get; private set; }
    public CombatUpState CombatUpState { get; private set; }

    public void Initialize(Facing facing, Inputs inputs)
    {
        _inputs = inputs;
        _combatStateMachine = new CombatStateMachine(this);

        CombatIdleState = new CombatIdleState(_combatStateMachine, ToggleHorizontalCombatMode, _data.IdleAttackParamName);
        CombatHorizontalState = new CombatHorizontalState(_combatStateMachine, ToggleHorizontalCombatMode, facing, _data.HorizontalAttackParamName);
        CombatUpState = new CombatUpState(_combatStateMachine, ToggleHorizontalCombatMode, _data.UpAttackParamName);

        _combatStateMachine.Start(CombatIdleState);
    }

    public void UpdateCombat()
    {
        _combatStateMachine.Update();
    }

    private void ToggleHorizontalCombatMode(bool value) 
    {
        _isInHorizontalCombat = value;
    }
}
