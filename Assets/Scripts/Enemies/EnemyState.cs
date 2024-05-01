using UnityEngine;

public class EnemyState : State
{
    private EnemyStateMachine _enemyStateMachine;
    private EnemyBase _enemyBase;
    private CharacterAnimator _animator;
    protected EnemyStateMachine Machine => _enemyStateMachine;
    protected EnemyBase EnemyBase => _enemyBase;
    protected CharacterAnimator Animator => _animator;
    public EnemyState(EnemyStateMachine machine)
    {
        _enemyStateMachine = machine;
        _enemyBase = _enemyStateMachine.EnemyBase;
        _animator = _enemyBase.Animator;
    }
}
