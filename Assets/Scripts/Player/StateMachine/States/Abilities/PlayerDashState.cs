using UnityEngine;

public class PlayerDashState : AbilityState
{
    public bool CanDash { get; private set; }

    private float _startTime;
    private float _lastDashTime;
    private float _startGravityScale;
    private DashStateData _data;
    private ParticleSystem[] _dashParticles;
    public PlayerDashState(PlayerStateMachine stateMachine, DashStateData data, ParticleSystem[] dashParticles) : base(stateMachine)
    {
        _data = data;
        _dashParticles = dashParticles;
    }

    public override void Enter()
    {
        base.Enter();
        CanDash = false;
        Player.Animator.ChangeAnimationState(_data.DashAnimationParameter, true);
        Player.Inputs.UseDashInput();
        foreach (var particle in _dashParticles) 
        {
            particle.transform.localScale = new Vector3(Player.Facing.FacingDirection, particle.transform.localScale.y, particle.transform.localScale.z);
            particle.Play();
        }
        _startTime = Time.time;
        _startGravityScale = Player.Rigidbody2D.gravityScale;
        Player.Rigidbody2D.gravityScale = 0f;
    }

    public override void Update()
    {
        Player.Rigidbody2D.velocity = new Vector2(_data.DashVelocity * Player.Facing.FacingDirection, 0);

        if (Time.time >= _startTime + _data.DashTime)
        {
            Player.Rigidbody2D.gravityScale = _startGravityScale;
            IsAbilityDone = true;
            _lastDashTime = Time.time;
        }

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        Player.Rigidbody2D.gravityScale = _startGravityScale;
        IsAbilityDone = true;
        _lastDashTime = Time.time;
        Player.Animator.ChangeAnimationState(_data.DashAnimationParameter, false);
    }

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= _lastDashTime + _data.DashCooldown;
    }

    public void ResetCanDash() => CanDash = true;
}
