using UnityEngine;

public class EnemyStateDataBase : ScriptableObject
{
    [SerializeField] private string _animationParamName;

    private Rigidbody2D _rigidBody2D;
    private CharacterAnimator _characterAnimator;
    private EnemyBase _enemyBase;
    protected Rigidbody2D RigidBody2D => _rigidBody2D;
    protected CharacterAnimator CharacterAnimator => _characterAnimator;
    protected EnemyBase EnemyBase => _enemyBase;

    public string AnimationParamName => _animationParamName;

    public virtual void SetReferences(Rigidbody2D rb, CharacterAnimator animator, EnemyBase enemyBase) 
    {
        _rigidBody2D = rb;
        _characterAnimator = animator;
        _enemyBase = enemyBase;
    }
    public virtual void EnterLogic() 
    {
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
