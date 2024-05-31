using System;
using UnityEngine;

public class JumpState : AbilityState
{
    private Action _createParticlesAction;
    private ParticleSystem[] _jumpParticles;
    private JumpStateData _data;
    public JumpState(PlayerStateMachine stateMachine, JumpStateData data, ParticleSystem[] jumpParticles, Action createParticles) : base(stateMachine)
    {
        _data = data;
        _jumpParticles = jumpParticles;
        _createParticlesAction = createParticles;
    }

    public override void Enter()
    {
        base.Enter();
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _data.JumpForce);
        PlayerInputs.UseJumpInput();
        Player.InAirState.SetIsJumping();
        Player.Sounds.PlayAbilitySound(_data.JumpSound);
        foreach (var particle in _jumpParticles)
        {
            particle.Play();
        }
        _createParticlesAction();
        IsAbilityDone = true;
    }
}
