using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class Bounce : MonoBehaviour
{
    public GameObject text;
    public GameObject textbox;
    public DialogueManager instructions;
    private Rigidbody2D rb;
    public float speed;
    [SerializeField] private Vector2 velocity;
    readonly System.Random r = new();
    private float rFloatX;
    private float rFloatY;
    public TMP_Text record;
    public TMP_Text result;
    public TMP_Text timerText;
    public TMP_Text buttonText;
    private float time;
    public Scenes scenes;
    public GameObject button;
    public GameObject blackScreen;

    void Start()
    {
        blackScreen.GetComponent<Animator>().Play("animation_black_in");
        rFloatX = r.Next(-3, 3);
        rFloatY = r.Next(-3, 3);
        while (rFloatX == 0 || rFloatY == 0) // This doesn't allow the ball to bounce horizontally or vertically
        {
            rFloatX = r.Next(-3, 3);
            rFloatY = r.Next(-3, 3);
        }

        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(rFloatX, rFloatY);
        velocity.Normalize();
        velocity *= speed;
    }

    void Update()
    {
        if (instructions.finished)
        {
            textbox.SetActive(false);
            rb.simulated = true;
            gameObject.SetActive(true);
            text.SetActive(false);
            rb.velocity = velocity;
        
            time = time += Time.deltaTime;
            timerText.text = time.ToString("0.0");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HorizontalWall"))
        {
            velocity = new Vector2(velocity.x, -velocity.y);
            // Bounce: Flipping the y velocity by multiplying it by -1
        }

        if (collision.gameObject.CompareTag("VerticalWall"))
        {
            velocity = new Vector2(-velocity.x, velocity.y);
            // Bounce: Flipping the x velocity by multiplying it by -1
        }

        if (collision.gameObject.CompareTag("Platform"))
        {
            // Vector2 currentVelocity = new Vector2(velocity.x, -velocity.y) * 1.1f;
            switch (velocity.x)
            {
                case >= 50:
                    velocity.x = 50;
                    break;
                case <= -50:
                    velocity.x = -50;
                    break;
                default:
                    velocity = new Vector2(velocity.x, -velocity.y) * 1.1f;
                    break;
            }
            
            // Increasing the speed every time the ball hits the platform by a little
        }

        if (collision.gameObject.CompareTag("Death"))
        {
            gameObject.SetActive(false);
            record.text = "Record: " + time.ToString("0.0");
            // Once the player misses the ball, it will hit the bottom and stopping the game
            if (time >= 10)
            {
                result.text = "Pass";
                buttonText.text = "- continue -";
            }
            else
            {
                result.text = "Fail";
                buttonText.text = "- restart -";
            }
            button.SetActive(true);
        }
    }
    public void NextScene()
    {
        if (result.text == "Pass")
        {
            scenes.ChangeScene();
        }
        else
        {
            scenes.ChangeScene2();
        }
    }
}
