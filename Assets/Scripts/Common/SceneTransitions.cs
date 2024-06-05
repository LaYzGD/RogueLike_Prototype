using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private int _nextSceneIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_nextSceneIndex);
    }
}
