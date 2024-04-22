public class PlayerStateMachine : StateMachine
{
    private Player _player;
    public Player Player => _player;


    public PlayerStateMachine(Player player)
    {
        _player = player;
    }
}
