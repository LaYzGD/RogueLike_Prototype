using System.Collections;
using UnityEngine;

public class EnemyDamageFlashEffect : MonoBehaviour
{
    [SerializeField] private string _colorReferenceNameID = "_FlashColor";
    [SerializeField] private string _floatReferenceNameID = "_FlashAmount";
    [SerializeField] private float _flashTime;
    [SerializeField][Range(0f, 1f)] private float _maxFlashAmount = 1f;
    [SerializeField][Range(0f, 1f)] private float _minFlashAmount = 0f;
    [SerializeField] private Color _flashColor;
    [SerializeField] private SpriteRenderer[] _sprites;
    [SerializeField] private Health _health;
    
    private Material[] _materials;

    private void Awake()
    {
        _materials = new Material[_sprites.Length];

        for (int i = 0; i < _sprites.Length; i++)
        {
            _materials[i] = _sprites[i].material;
        }
    }

    private void OnEnable()
    {
        _health.OnDamaged += AplyFlashEffect;
    }

    private void AplyFlashEffect(int currentHealth)
    {
        StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        SetFlashColor(_flashColor);
        var currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < _flashTime)
        {
            elapsedTime += Time.deltaTime;
            currentFlashAmount = Mathf.Lerp(_maxFlashAmount, _minFlashAmount, elapsedTime / _flashTime);
            SetFlashAmount(currentFlashAmount);
            yield return null;
        }
    }

    private void SetFlashColor(Color color)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetColor(_colorReferenceNameID, color);
        }
    }

    private void SetFlashAmount(float flashAmount)
    {
        for (int i = 0; i < _materials.Length; i++)
        {
            _materials[i].SetFloat(_floatReferenceNameID, flashAmount);
        }
    }

    private void OnDisable()
    {
        _health.OnDamaged -= AplyFlashEffect;
    }
}
