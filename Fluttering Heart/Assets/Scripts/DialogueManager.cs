using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text textComponent;
    public bool finished;
    public string[] lines;
    public float textSpeed;
    public int index;
    Coroutine TypeLineHandle;
    bool typing;
    
    void Start()
    {
        textComponent.text = string.Empty;
        index = 0;
        TypeLineHandle = StartCoroutine(TypeLine());
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
            else if(typing ==true)
            {
                typing = false;
                StopCoroutine(TypeLineHandle);
                textComponent.text = lines[index];
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
        typing = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        typing = false;
    }

    // Determine wheither or not the dialogue needs to move on the next line
    void NextLine()
    {
        textComponent.text = string.Empty;
        if (index < lines.Length - 1)
        {
            index++;
            TypeLineHandle = StartCoroutine(TypeLine());
        }
        else
        {
            finished = true;
        }
    }
}
