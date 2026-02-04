using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject credits;
    public GameObject backButton;
    public GameObject startButton;
    public GameObject creditButton;

    // Shows credits
    public void CreditsAppear()
    {
        startButton.SetActive(false);
        creditButton.SetActive(false);
        credits.SetActive(true);
        backButton.SetActive(true);
    }

    // Hide credits
    public void Back()
    {
        startButton.SetActive(true);
        creditButton.SetActive(true);
        credits.SetActive(false);
        backButton.SetActive(false);
    }
}
