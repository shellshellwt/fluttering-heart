using System.Collections;
using UnityEngine;
using TMPro;

public class HeartBeat : MonoBehaviour
{
    public int sceneNumber;
    public TMP_Text heartBeat;
    public GameObject heart;
    public string startBeat;
    public string endBeat;
    public float waitTime;
    public CharacterManager characterManager;
    public DialogueManager DMScene5;
    public Scenes scenes;
    public GameObject pinkBlur;
    private bool active = false;
    
    void Start()
    {
        heartBeat.text = startBeat;
    }

    // Activates different coroutines in different scenes
    void Update()
    {
        if (!active)
        {
            switch (sceneNumber)
            {
                case 2:
                    pinkBlur.SetActive(false);
                    if (characterManager.touched)
                    {
                        StartCoroutine(Scene2());
                        active = true;
                    }
                    break;
                case 3:
                    StartCoroutine(Scene3());
                    active = true;
                    break;
                case 5:
                    if (DMScene5.finished)
                    {
                        StartCoroutine(Scene5());
                        active = true;
                    }
                    break;
                case 6:
                    heart.GetComponent<Animator>().Play("heart_beats");
                    break;
            }
        }
    }

    // Changes the heartrate from time to time in scene 2
    IEnumerator Scene2()
    {
        
        pinkBlur.SetActive(true);
        heart.GetComponent<Animator>().Play("heart_beats");
        heartBeat.text = "95";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "102";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "117";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "122";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "125";
        scenes.ChangeScene();
    }

    // Changes the heartrate from time to time in scene 3
    IEnumerator Scene3()
    {
        pinkBlur.SetActive(false);
        heart.GetComponent<Animator>().Play("heart_beats");
        heartBeat.text = "120";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "113";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "105";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "98";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "95";
        heart.GetComponent<Animator>().StopPlayback();
    }

    // Changes the heartrate from time to time in scene 5
    IEnumerator Scene5()
    {
        pinkBlur.SetActive(true);
        heart.GetComponent<Animator>().Play("heart_beats");
        heartBeat.text = "100";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "118";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "127";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "138";
        yield return new WaitForSeconds(waitTime);
        heartBeat.text = "140";
    
        scenes.ChangeScene();
    }

}
