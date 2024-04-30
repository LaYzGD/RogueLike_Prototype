using System;
using UnityEngine;

public class EnemyPoolable : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private Action<EnemyPoolable> _onDie;

    public void Init(Action<EnemyPoolable> onDie, Vector2 pos)
    {
        _onDie = onDie;
        transform.position = pos;
        _enemy.Init();
        _enemy.gameObject.SetActive(true);
        _enemy.OnDie += CallDieAction;
    }

    private void CallDieAction()
    {
        _onDie(this);
        _enemy.OnDie -= CallDieAction;
    }

}
