using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneLoader sceneLoader = new SceneLoader();

        sceneLoader.Load("Assets/Scenes/Game.unity");
    }

    public void Exit()
    {

    }

    public void ShowCreators()
    {

    }
}
