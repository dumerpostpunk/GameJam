using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float speed;

    private Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        InputManager();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

    }
    private void InputManager()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction = new Vector2(direction.x, direction.y).normalized;
    }
    private void UpdateAnimation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        animator.SetBool("isMoving", direction != Vector2.zero);
        animator.SetBool("front", mousePosition.y < transform.position.y);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");

        }
        spriteRenderer.flipX = (mousePosition.x < transform.position.x);

    }
}

