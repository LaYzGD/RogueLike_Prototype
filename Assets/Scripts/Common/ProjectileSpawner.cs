using UnityEngine;
using UnityEngine.Pool;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField] private Projectile _projectile;

    private ProjectileData _projectileData;
    private ObjectPool<Projectile> _pool;

    public void Initialize(ProjectileData projectileData)
    {
        _projectileData = projectileData;
        _pool = new ObjectPool<Projectile>(() => Instantiate(_projectile),
                                           (p) => p.gameObject.SetActive(true),
                                           (p) => p.gameObject.SetActive(false),
                                           (p) => Destroy(p.gameObject),
                                           false);
    }

    public void SpawnProjectile(Vector2 direction, Vector2 position, Quaternion rotation)
    {
        var proj = _pool.Get();
        proj.transform.position = position;
        proj.transform.rotation = rotation;
        proj.Initialize(DespawnProjectile, direction, _projectileData);
    }

    private void DespawnProjectile(Projectile p)
    {
        _pool.Release(p);
    }
}
