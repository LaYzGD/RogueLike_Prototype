using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _animationTriggerName;
    [SerializeField] private CharacterAnimator _animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.ChangeAnimationState(_animationTriggerName);
    }
}
