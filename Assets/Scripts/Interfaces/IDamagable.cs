using UnityEngine;

public interface IDamagable
{
    public abstract void TakeDamage(int damage, Vector2 direction);
}
