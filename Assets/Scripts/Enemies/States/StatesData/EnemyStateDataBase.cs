using UnityEngine;

public class EnemyStateDataBase : ScriptableObject
{
    [SerializeField] private string _animationParamName;

    private Rigidbody2D _rigidBody2D;
    private CharacterAnimator _characterAnimator;
    private EnemyBase _enemyBase;
    private Transform _target;
    private Facing _facing;
    protected Rigidbody2D RigidBody2D => _rigidBody2D;
    protected CharacterAnimator CharacterAnimator => _characterAnimator;
    protected EnemyBase EnemyBase => _enemyBase;
    protected Transform Target => _target;
    protected Facing Facing => _facing;

    public string AnimationParamName => _animationParamName;

    public virtual void SetReferences(Rigidbody2D rb, CharacterAnimator animator, EnemyBase enemyBase) 
    {
        _rigidBody2D = rb;
        _characterAnimator = animator;
        _enemyBase = enemyBase;
        _target = EnemyBase.Target;
        _facing = enemyBase.Facing;
    }

    public virtual void CheckTarget()
    {
        if (_target == null)
        {
            return;
        }

        if (_target.position.x > EnemyBase.Body.position.x && _facing.FacingDirection < 0)
        {
            _facing.Flip();
        }
        else if (_target.position.x < EnemyBase.Body.position.x && _facing.FacingDirection > 0)
        {
            _facing.Flip();
        }
    }

    public virtual void ChangeState()
    {
        var nextState = EnemyBase.GetNextState();
        switch (nextState)
        {
            case EnemyStateType.Attack:
                CheckAttackState();
                break;
            case EnemyStateType.Idle:
                EnemyBase.StateMachine.ChangeState(EnemyBase.IdleState);
                break;
            case EnemyStateType.Move:
                EnemyBase.StateMachine.ChangeState(EnemyBase.MoveState);
                break;
        }
    }

    public virtual void CheckAttackState()
    {
        if (CheckTargetClose())
        {
            if (EnemyBase.Attacks.CloseAttacks.Count > 0)
            {
                EnemyBase.SetNewAttackData(EnemyBase.Attacks.CloseAttacks[UnityEngine.Random.Range(0, EnemyBase.Attacks.CloseAttacks.Count)]);
            }
        }
        else if (CheckTargetFar())
        {
            if (EnemyBase.Attacks.DistantAttacks.Count > 0)
            {
                EnemyBase.SetNewAttackData(EnemyBase.Attacks.DistantAttacks[UnityEngine.Random.Range(0, EnemyBase.Attacks.DistantAttacks.Count)]);
            }
        }
        else
        {
            EnemyBase.SetNewAttackData(EnemyBase.Attacks.DefaultAttacks[UnityEngine.Random.Range(0, EnemyBase.Attacks.DefaultAttacks.Count)]);
        }
        EnemyBase.StateMachine.ChangeState(EnemyBase.AttackState);
    }


    public virtual bool CheckTargetClose()
    {
        if (_target == null) return false;

        if (Vector2.Distance(_target.position, EnemyBase.Body.position) <= EnemyBase.CloseThreshold)
        {
            return true;
        }

        return false;
    }

    public virtual bool CheckTargetFar()
    {
        if (_target == null) return false;

        if (Vector2.Distance(_target.position, EnemyBase.Body.position) >= EnemyBase.FarThreshold)
        {
            return true;
        }

        return false;
    }

    public virtual void EnterLogic() 
    {
        CheckTarget();
        _characterAnimator.ChangeAnimationState(_animationParamName, true);
    }
    public virtual void UpdateLogic() { }
    public virtual void FixedUpdateLogic() { }
    public virtual void DoChecksLogic() { }
    public virtual void AnimationTriggerLogic() { }
    public virtual void AnimationCompletedLogic() { }
    public virtual void ExitLogic() 
    {
        _characterAnimator.ChangeAnimationState(_animationParamName, false);
    }
}
