using UnityEngine;

public class CharacterLoseUI : MonoBehaviour
{
    [SerializeField] private GameObject _loseScreen;
    private SceneTransitions _transitions;
    
    public void Init(SceneTransitions sceneTransitions)
    {
        _transitions = sceneTransitions;
    }

    public void ShowLoseView()
    {
        _loseScreen.SetActive(true);
    }

    public void GoToMenu()
    {
        _transitions.LoadNewScene(0);
    }
}
