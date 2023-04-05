using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _creatorsPanel;
    public void Play()
    {
        SceneLoader sceneLoader = new SceneLoader();

        sceneLoader.Load("Assets/Scenes/Game.unity");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowCreators()
    {
        _creatorsPanel.SetActive(true);
    }
}
