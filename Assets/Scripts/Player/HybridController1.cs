using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HybridController : MonoBehaviour
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

    }
    private void InputManager()
    {

    }
    private void UpdateAnimation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
       
        animator.SetBool("front", mousePosition.y < transform.position.y);
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");

        }
        spriteRenderer.flipX = (mousePosition.x < transform.position.x);

    }
}

