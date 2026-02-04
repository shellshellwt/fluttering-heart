using System.Collections;
using TMPro;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public Scenes Scenes;
    public TMP_Text textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    public GameObject blackScreen;
    public GameObject cam;
    
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(TypeLine());
    }

    // Gets the mouse input and moves on to the next line of dialogue
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    // Types the line of dialogue with delay, as if its typing the letters
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    // Determine whether or not the dialogue needs to move on the next line or to another scene
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Animator>().Play("animation_black_out");
            cam.GetComponent<Animator>().Play("cam_zoom_in");
            Invoke(nameof(NextScene), 2.3f);
        }
    }

    void NextScene()
    {
        Scenes.ChangeScene();
    }
}
