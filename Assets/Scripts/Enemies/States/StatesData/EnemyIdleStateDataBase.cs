using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/IdleState/EnemyIdleStateData", fileName = "IdleStateData")]
public class EnemyIdleStateDataBase : EnemyStateDataBase
{
    [SerializeField] private float _timeLeft;
    [SerializeField] private bool _canDetectTarget = false;
    private float _currentTime;
    public override void EnterLogic()
    {
        base.EnterLogic();
        _currentTime = Time.time;
        RigidBody2D.velocity = Vector2.zero;
    }

    public override void UpdateLogic()
    {
        if (_canDetectTarget)
        {
            CheckTarget();

            if (EnemyBase.TargetDetection.CheckFront())
            {
                CheckAttackState();
                return;
            }
        }

        if (Time.time >= _currentTime + _timeLeft)
        {
            ChangeState();
        }
    }
}
