using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private readonly float speed = 8f;
    private readonly float jumpPower = 16f;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Scenes scenes;
    public DialogueManager instructions;
    public GameObject textbox;
    public GameObject instructionsText;
    public GameObject blackScreen;
    void Update()
    {
        if (instructions.finished)
        {
            instructionsText.SetActive(false);
            textbox.SetActive(false);
            horizontal = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && IsGrounded()) // Player only jumps when they are touching the ground
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        // Checks if the player is touching the ground
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        // When the player falls from the platforms, they are respawned at the start
        if (collider.gameObject.CompareTag("Death"))
        {
            gameObject.transform.position = new Vector2(-1.15f, -3.4f);
        }
        // When the player touches the exit, they are teleported to the next scene
        if (collider.gameObject.CompareTag("Exit"))
        {
            blackScreen.SetActive(true);
            blackScreen.GetComponent<Animator>().Play("animation_black_out");
            Invoke(nameof(NextScene), 2.3f);
        }
    }

    void NextScene()
    {
        scenes.ChangeScene();
    }
}