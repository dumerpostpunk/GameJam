using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Rigidbody2D body;

    private Vector2 _move;

    private float horizontal;
    private float vertical;

    [SerializeField] private float runSpeed = 20.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        _move = new Vector2(horizontal, vertical).normalized;
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(_move.x * runSpeed, _move.y * runSpeed);
    }
}
