using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class PressButton : MonoBehaviour
{
    private static readonly WaitForSeconds _waitForSeconds0_25 = new(0.25f);
    private static readonly WaitForSeconds _waitForSeconds0_2 = new(0.2f);
    public TMP_Text scoreBoard;
    public GameObject continueButton;
    public TMP_Text resultText;
    public DialogueManager instructions;
    public GameObject panel;
    public GameObject text;
    public Sprite original;
    public Sprite lightUp;
    public GameObject[] buttons;
    private readonly int[] storage = new int[5];
    private bool complete;
    private int guess = -1;
    private bool pressed = false;

    private readonly System.Random r = new();

    void Start()
    {
        continueButton.SetActive(false);
        complete = false;
    }

    void Update()
    {
        if (instructions.finished)
        {
            StartCoroutine(Game());
            text.SetActive(false);
            panel.SetActive(false);
            instructions.finished = false;
        }
    }

    public IEnumerator Game()
    {
        int counter = 0;
        int correct = 0;
        for (int i = 0; i < 5; i++)
        {
            int rInt = r.Next(0, 10); // Gets a random number
            storage[i] = rInt; // Stores the number in the array
            for (int j = 0; j <= counter; j++)
            {
                // Plays the buttons in sequence
                yield return _waitForSeconds0_2;
                buttons[storage[j]].GetComponent<Image>().sprite = lightUp;
                yield return _waitForSeconds0_25;
                buttons[storage[j]].GetComponent<Image>().sprite = original;
                yield return _waitForSeconds0_2;
            }

            for (int k = 0; k <= counter; k++)
            {
                // Player presses the buttons
                while (guess == -1)
                {
                    yield return new WaitUntil(ButtonPressed);
                }
                if (guess == storage[k]) // Checks if they are correct
                {
                    correct++;
                }
                guess = -1;
                pressed = false;
            }
            counter++;
        }

        // Outputs if the player passed the game or not
        if (correct >= 15)
        {
            scoreBoard.text = "You got all of them correct!";
            complete = true;
            resultText.text = "- continue -";
        }
        else if (correct >= 12)
        {
            scoreBoard.text = "You got a few of them wrong.";
            resultText.text = "- restart -";
        }
        else if (correct >= 6)
        {
            scoreBoard.text = "You got some of them wrong.";
            resultText.text = "- restart -";
        }
        else if (correct <= 5)
        {
            scoreBoard.text = "You got most of them wrong.";
            resultText.text = "- restart -";
        }
        panel.SetActive(true);
        continueButton.SetActive(true);
    }

    // Gets the button inputs
    public bool ButtonPressed()
    {
        return pressed;
    }

    public void Click0()
    {
        guess = 0;
        pressed = true;
    }

    public void Click1()
    {
        guess = 1;
        pressed = true;
    }

    public void Click2()
    {
        guess = 2;
        pressed = true;
    }

    public void Click3()
    {
        guess = 3;
        pressed = true;
    }

    public void Click4()
    {
        guess = 4;
        pressed = true;
    }

    public void Click5()
    {
        guess = 5;
        pressed = true;
    }

    public void Click6()
    {
        guess = 6;
        pressed = true;
    }

    public void Click7()
    {
        guess = 7;
        pressed = true;
    }

    public void Click8()
    {
        guess = 8;
        pressed = true;
    }

    public void Click9()
    {
        guess = 9;
        pressed = true;
    }

    // Loads the next scene or reloads the current scene
    public void Continue()
    {
        if (complete)
        {
            SceneManager.LoadScene(9);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }
}
