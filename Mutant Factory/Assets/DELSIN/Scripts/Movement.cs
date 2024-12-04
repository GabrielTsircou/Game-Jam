using UnityEngine;

public class Movement : MonoBehaviour
{
    private float move;

    private Vector2 CheckyPointy;

    public KeyCode left, right, up, down;
    public float maxSpeed;
    public float buildUp;
    float input;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D moveit;
    void Start()
    {
        moveit = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(left))
        {
            moveit.AddForce(Vector2.left * buildUp);
        }
        if (UnityEngine.Input.GetKey(right))
        {
            moveit.AddForce(Vector2.right * buildUp);
        }
        if (UnityEngine.Input.GetKey(up))
        {
            moveit.AddForce(Vector2.up * buildUp);
        }
        if (UnityEngine.Input.GetKey(down))
        {
            moveit.AddForce(Vector2.down * buildUp);
        }

        input = Input.GetAxisRaw("Horizontal");
        if (input < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (input > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
    
