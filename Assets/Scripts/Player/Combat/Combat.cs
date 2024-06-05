using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] private CombatData _data;
    [SerializeField] private Weapon _weapon;
    [SerializeField] private Transform _horizontalCheckOrigin;
    [SerializeField] private Transform _verticalCheckOrigin;
    [SerializeField] private CharacterAnimator _weaponAnimator;


    private bool _isInHorizontalCombat;

    public CharacterAnimator WeaponAnimator => _weaponAnimator;
    public bool IsInHorizontalCombat => _isInHorizontalCombat;

    private CombatStateMachine _combatStateMachine;
    public CombatIdleState CombatIdleState { get; private set; }
    public CombatHorizontalState CombatHorizontalState { get; private set; }
    public CombatUpState CombatUpState { get; private set; }

    public void Initialize(Facing facing, int damage)
    {
        _combatStateMachine = new CombatStateMachine(this);
        _weapon.Init(damage);
        CombatIdleState = new CombatIdleState(_combatStateMachine, facing, ToggleHorizontalCombatMode, _data.IdleAttackParamName, _horizontalCheckOrigin, _verticalCheckOrigin, _data);
        CombatHorizontalState = new CombatHorizontalState(_combatStateMachine, facing, ToggleHorizontalCombatMode, _data.HorizontalAttackParamName, _horizontalCheckOrigin, _verticalCheckOrigin, _data);
        CombatUpState = new CombatUpState(_combatStateMachine, facing, ToggleHorizontalCombatMode, _data.UpAttackParamName, _horizontalCheckOrigin, _verticalCheckOrigin, _data);

        _combatStateMachine.Start(CombatIdleState);
    }

    public void UpdateDamage(int damage)
    {
        _weapon.Init(damage);
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
