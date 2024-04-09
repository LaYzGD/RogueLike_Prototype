using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private DistanceJoint2D _joint;
    [SerializeField] private HookData _hookData;
    [SerializeField] private float _returnCheckTreshold = 0.4f;

    public event Action OnReturned;
    public event Action OnGrappled;

    public void Launch(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _hookData.TravelDistance, _hookData.ConnectableLayer.value);

        if (hit.collider != null)
        {
            _joint.connectedAnchor = hit.point;
            _joint.enabled = true;
            _joint.distance = _hookData.Distance;
            OnGrappled?.Invoke();
            return;
        }

        OnReturned?.Invoke();
    }

    public void Ungrapple()
    {
        _joint.enabled = false;
    }
}
