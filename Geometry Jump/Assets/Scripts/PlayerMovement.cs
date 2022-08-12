using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] public float speed = 10f;
    [SerializeField] private float jump = 700f;
    private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask groundLayer;
    private Animator anim;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody cameraRB;
    public bool isHit = false;
    private playerSlide ps;
    private bool isSliding;
    private PlayerAttack pa;
    public bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        ps = GetComponent<playerSlide>();
        pa = GetComponent<PlayerAttack>();

    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = pa.isAttacking;
        isSliding = ps.isSliding;
        // Move code
        if (isAttacking == false && isHit == false)
            body.velocity = new Vector2(speed, body.velocity.y);
        else
            body.velocity = new Vector2(0, 0);
        // Jump Code

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded() && isHit == false)
        {
            body.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

        }
        if (isGrounded() == false)
        {
            anim.SetBool("jump", true);
        }
        else
        {
            anim.SetBool("jump", false);
        }


    }

    public bool canShoot()
    {
        return (isSliding == false) && isGrounded();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Obstacle"))
        {
            anim.SetBool("hit", true);
            isHit = true;
            body.velocity = new Vector2(0, 0);
            Debug.Log("Player hit!");
            Destroy(gameObject, 2.2f);
        }
    }

    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
        return raycastHit.collider != null;
    }
}
