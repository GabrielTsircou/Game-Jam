using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (PrePosition.scenePosPre.ContainsKey(SceneManager.GetActiveScene().name))
            transform.position = PrePosition.scenePosPre[SceneManager.GetActiveScene().name];
    }
    void Update()
    {
        if (UnityEngine.Input.GetKey(left))
        {
            moveit.AddForce(Vector2.left * buildUp * Time.deltaTime);
        }
        if (UnityEngine.Input.GetKey(right))
        {
            moveit.AddForce(Vector2.right * buildUp * Time.deltaTime);
        }
        if (UnityEngine.Input.GetKey(up))
        {
            moveit.AddForce(Vector2.up * buildUp * Time.deltaTime);
        }
        if (UnityEngine.Input.GetKey(down))
        {
            moveit.AddForce(Vector2.down * buildUp * Time.deltaTime);
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
    
