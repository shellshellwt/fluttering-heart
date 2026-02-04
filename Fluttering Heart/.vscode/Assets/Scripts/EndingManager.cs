using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public GameObject yesButton;
    public GameObject noButton;
    public GameObject Text;
    public DialogueManager dialogueManager;
    public int endingSceneNum;
    public GameObject blackScreen;
    public GameObject cam;

    void Start()
    {
        if (endingSceneNum == 0)
        {
            cam.GetComponent<Animator>().Play("cam_zoom_out");
            blackScreen.GetComponent<Animator>().Play("animation_black_in");
            yesButton.SetActive(false);
            noButton.SetActive(false);
            Text.SetActive(false);
        }
        else if (endingSceneNum == 3)
        {
            blackScreen.GetComponent<Animator>().Play("animation_black_in");
        }
    }

    // Ending scene, after the dialogue ends, buttons will appear to let the player to choose their fate  
    void Update()
    {
        if (endingSceneNum == 3)
        {
            Invoke(nameof(BlackScreenAppear), 5);
            Invoke(nameof(Quit), 7);
        }
        else if (dialogueManager.finished)
        {
            switch (endingSceneNum) {
                case 0:
                    yesButton.SetActive(true);
                    noButton.SetActive(true);
                    Text.SetActive(true);
                    break;
                case 1:
                    BlackScreenAppear();
                    Invoke(nameof(Quit), 2);
                    break;
                case 2:
                    BlackScreenAppear();
                    cam.GetComponent<Animator>().Play("cam_zoom_in");
                    Invoke(nameof(NextScene), 2);
                    break;
            }
        }        
    }
    // Stops the running game
    private void Quit()
    {
        Application.Quit();
    }

    private void BlackScreenAppear()
    {
        blackScreen.SetActive(true);
        blackScreen.GetComponent<Animator>().Play("animation_black_out", 0);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(15);
    }
}
