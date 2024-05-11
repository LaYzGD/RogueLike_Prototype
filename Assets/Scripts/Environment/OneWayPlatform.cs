using System.Collections;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    [SerializeField] private PlatformEffector2D _effector;
    [SerializeField] private float _timeToWait = 0.5f;

    private float _arc;

    private void Start()
    {
        _arc = _effector.surfaceArc;
    }

    public void DropDown()
    {
        _effector.surfaceArc = 0f;
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(_timeToWait);
        _effector.surfaceArc = _arc;
    }
}
