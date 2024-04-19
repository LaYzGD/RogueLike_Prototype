using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    public void TakeDamage(int damage)
    {
        Debug.Log(damage);
    }
}
