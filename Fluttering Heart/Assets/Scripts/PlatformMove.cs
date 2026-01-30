using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private float leftSide;
    private float rightSide;

    // Start is called before the first frame update
    void Start()
    {
        // Gets the edge of the scene and doesn't allow the platform to go out of the scene
        leftSide = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        rightSide = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX;
        // Controls where the platform moves where the mouse moves
        mouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        mouseX = Mathf.Clamp(mouseX, leftSide, rightSide);
        transform.position = new Vector2(mouseX, transform.position.y);
    }
}
