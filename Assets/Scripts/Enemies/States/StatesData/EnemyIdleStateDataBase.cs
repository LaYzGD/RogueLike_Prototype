using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy/IdleState/EnemyIdleStateData", fileName = "IdleStateData")]
public class EnemyIdleStateDataBase : EnemyStateDataBase
{
    [SerializeField] private float _timeLeft;
    private float _currentTime;
    public override void EnterLogic()
    {
        base.EnterLogic();
        _currentTime = Time.time;
        RigidBody2D.velocity = Vector2.zero;
    }

    public override void UpdateLogic()
    {
        if (Time.time >= _currentTime + _timeLeft)
        {
            ChangeState();
        }
    }
}
