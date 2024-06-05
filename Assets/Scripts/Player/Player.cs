using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializeFields
    [Header("Components")]
    [SerializeField] private Inputs _inputs;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private Combat _combat;
    [SerializeField] private Health _health;
    [SerializeField] private HealthUI _healthUI;
    [SerializeField] private PlayerSounds _sounds;
    [SerializeField] private ParticleSystem _hitParticles;
    [SerializeField] private ParticleSystem[] _dashParticles;
    [SerializeField] private ParticleSystem[] _jumpParticles;
    [SerializeField] private UpgradeUI _upgradeUI;
    [SerializeField] private RunProgressionSaving _saving;
    [Space]
    [SerializeField] private GameObject _dustParticles;
    [SerializeField] private Transform _dustParticlesSpawn;
    [Header("Data")]
    [SerializeField] private PlayerData _playerOriginalData;
    [SerializeField] private AudioClip _hitSound;
    [Header("Variables")]
    [SerializeField] private int _facingDirection = 1;
    #endregion

    #region States
    public InAirState InAirState { get; private set; }
    public IdleState IdleState { get; private set; }
    public MoveState MoveState { get; private set; }
    public LandState LandState { get; private set; }
    public JumpState JumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    #endregion

    #region Private Fields
    private Checker _checker;
    private Facing _facing;
    private PlayerStateMachine _stateMachine;
    private PlayerData _playerData;
    private SceneTransitions _transitions;
    #endregion

    #region Getters
    public Inputs Inputs => _inputs;
    public Rigidbody2D Rigidbody2D => _rigidbody2D;
    public Checker Checker => _checker;
    public CharacterAnimator Animator => _characterAnimator;
    public Combat Combat => _combat;
    public Facing Facing => _facing;
    public PlayerSounds Sounds => _sounds;
    #endregion

    public void Init(SceneTransitions transitions)
    {
        _transitions = transitions;
        _playerData = Instantiate(_playerOriginalData);
        var dataValues = _saving.Load(_playerOriginalData);
        _playerData.SetUp(dataValues);
        _checker = new Checker(_collider, _playerData.GroundCheckData, _rigidbody2D);
        _facing = new Facing(transform, _facingDirection);
        _stateMachine = new PlayerStateMachine(this);

        InAirState = new InAirState(_stateMachine,
                                    _playerData.AirStateData,
                                    _playerData.MoveStateData,
                                    _facing,
                                    _playerData.CharacterAnimationsData.InAirAnimationParameter);
        IdleState = new IdleState(_stateMachine,
                                  _playerData.CharacterAnimationsData.IdleAnimationParameter);
        MoveState = new MoveState(_stateMachine,
                                  _playerData,
                                  _facing,
                                  _playerData.CharacterAnimationsData.MoveAnimationParameter);
        LandState = new LandState(_stateMachine);
        JumpState = new JumpState(_stateMachine, _playerData.JumpStateData, _jumpParticles, CreateDustParticles);
        DashState = new PlayerDashState(_stateMachine, _playerData.DashStateData, _dashParticles, CreateDustParticles);
        _combat.Initialize(_facing, _playerData.Damage);
        _healthUI.Init(_health);
        _health.Init(_playerData.MaxHealth, dataValues.CurrentHealth, false);
        _upgradeUI.Init(Upgrade);

        _stateMachine.Start(IdleState);
        _health.OnDamaged += Damaged;
        _health.OnDie += Die;
    }

    private void Damaged(int health, Vector2 direction)
    {
        _health.SetImune(true);
        _hitParticles.Play();
        _sounds.PlayHitSound(_hitSound);
        StartCoroutine(ImunityFrames());
    }

    private void Die()
    {
        _saving.Save(_playerOriginalData, _playerOriginalData.MaxHealth);
        print("Dead");
    }

    public void ShowUpgrade()
    {
        _upgradeUI.Show();
    }

    private void Upgrade(UpgradeProperty property, int boostAmount)
    {
        if (property == UpgradeProperty.RestoreHealth)
        {
            _health.Heal(boostAmount);
            _saving.Save(_playerData, _health.CurrentHealth);
            _transitions.ChangeScene();
            return;
        }

        _playerData.UpdateData(property, boostAmount);
        _health.UpdateMaxHealth(_playerData.MaxHealth);
        _combat.UpdateDamage(_playerData.Damage);
        _saving.Save(_playerData, _health.CurrentHealth);
        _transitions.ChangeScene();
    }

    private void Update()
    {
        _stateMachine.Update();
        _combat.UpdateCombat();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void CreateDustParticles()
    {
        Instantiate(_dustParticles, _dustParticlesSpawn.position, Quaternion.identity);
    }

    private IEnumerator ImunityFrames()
    {
        yield return new WaitForSecondsRealtime(_playerData.ImunityFramesTime);
        _health.SetImune(false);
    }
}
