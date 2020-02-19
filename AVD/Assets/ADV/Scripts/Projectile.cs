using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 23f;
    [SerializeField] private LayerMask collisionMask;
    private Rigidbody2D rb;
    private Animator animator;

    private int horizontal = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        transform.Translate(Vector2.right * horizontal * moveSpeed * Time.deltaTime);
        if (rb.IsTouchingLayers(collisionMask))
        {
            horizontal = 0;
            animator.SetTrigger("explode");
            Destroy(gameObject, .267f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void SetDirection(int playerControllerFacingRight)
    {
        horizontal = playerControllerFacingRight;
    }
}