using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public int changeToScene;
    public int changeToScene2;

    
    public void ChangeScene()
    {
        SceneManager.LoadScene(changeToScene);
    }

    // Changes scene choice 2
    public void ChangeScene2()
    {
        SceneManager.LoadScene(changeToScene2);
    }

}
