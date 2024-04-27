using UnityEngine;

public class EnemyState : State
{
    private EnemyStateMachine _stateMachine;
    private Enemy _enemy;
    private Facing _facing;
    private Rigidbody2D _rigidBody2D;
    private CharacterAnimator _characterAnimator;

    protected EnemyStateMachine StateMachine => _stateMachine;
    protected Enemy Enemy => _enemy;
    protected Facing Facing => _facing;
    protected Rigidbody2D Rigidbody2D => _rigidBody2D;
    protected CharacterAnimator Animator => _characterAnimator;

    public EnemyState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
        _enemy = _stateMachine.Enemy;
        _facing = _enemy.Facing;
        _rigidBody2D = _enemy.Rigidbody2D;
        _characterAnimator = _enemy.Animator;
    }

    public virtual void DoChecks() 
    {
    }
}
