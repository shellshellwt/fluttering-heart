using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public int sceneNumber;
    public DialogueManager dialogueManager;
    public GameObject boy;
    public GameObject textbox;
    public GameObject blackScreen;
    public GameObject bumpText;
    public GameObject touchText;
    public GameObject blur;
    public GameObject move;
    public GameObject sleeping;
    public bool touched;
    public Scenes sceneManager;

    void Start()
    {
        switch (sceneNumber)
        {
            case 1:
                boy.SetActive(false);
                bumpText.SetActive(false);
                blackScreen.SetActive(false);
                break;
            case 2:
                boy.SetActive(true);
                touchText.SetActive(false);
                break;
            case 3:
                boy.SetActive(true);
                break;
            case 4:
                blur.SetActive(false);
                break;
            case 5:
                blackScreen.SetActive(true);
                blackScreen.GetComponent<Animator>().Play("animation_black_in", 0);
                blur.SetActive(false);
                break;
            case 6:
                move.GetComponent<Animator>().Play("reverse_move", 0);
                break;
        }
        
    }

    // Controlling what happens to the characters, animations and effects
    void Update()
    {
        switch (sceneNumber)
        {
            case 1:
                if (dialogueManager.finished)
                {
                    boy.SetActive(true);
                    Invoke(nameof(Bumped), 1);
                    Invoke(nameof(ChangeScene), 3);
                }
                break;
            case 2:
                if (dialogueManager.finished)
                {
                    Invoke(nameof(Touch), 1f);
                }
                break;
            case 3:
                if (dialogueManager.finished)
                {
                    blackScreen.SetActive(true);
                    blackScreen.GetComponent<Animator>().Play("animation_black_out", 0);
                    Invoke(nameof(Scene), 2);
                }
                break;
            case 4:
                if (dialogueManager.index == 2)
                {
                    blackScreen.SetActive(true);
                    blackScreen.GetComponent<Animator>().Play("animation_black_in", 0);
                }
                else if (dialogueManager.index == 10)
                {
                    blackScreen.GetComponent<Animator>().Play("animation_black_out", 0);
                    Invoke(nameof(Scene), 2);
                }
                break;
            case 5:
                switch (dialogueManager.index)
                {
                    case 3:
                        move.GetComponent<Animator>().Play("move", 0);
                        break;
                    case 6:
                        sleeping.SetActive(false);
                        break;
                    case 7:
                        boy.GetComponent<Animator>().Play("closer", 0);
                        break;
                }
                break;
            case 6:
                if (dialogueManager.index == 3)
                {
                    move.GetComponent<Animator>().Play("move", 0);
                }

                if (dialogueManager.finished)
                {
                    blackScreen.SetActive(true);
                    blur.SetActive(false);
                    blackScreen.GetComponent<Animator>().Play("animation_black_out", 0);
                    Invoke(nameof(Scene), 2f);
                }
                break;
            case 7:
                if (dialogueManager.finished)
                {
                    blackScreen.SetActive(true);
                    blackScreen.GetComponent<Animator>().Play("animation_black_out");
                    Invoke(nameof(Scene), 2f);
                }
                break;
        }
            
    }

    // This is when you bumped into Him in the story
    void Bumped()
    {
        bumpText.SetActive(true);
        blackScreen.SetActive(true);
        blackScreen.transform.position = new Vector3(0, 0, -1);
        blackScreen.GetComponent<Animator>().Play("animation_black_out", 0);
    }
    void ChangeScene()
    {
        bumpText.SetActive(false);
        textbox.SetActive(false);
        sceneManager.ChangeScene();
    }
    void Touch()
    {
        touchText.SetActive(true);
        touched = true;
    }
    void Scene()
    {
        sceneManager.ChangeScene();
    }
}
