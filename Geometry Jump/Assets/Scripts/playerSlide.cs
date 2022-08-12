using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSlide : MonoBehaviour
{
    public bool isSliding = false;
    public PlayerMovement pm;
    private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D regularCollider;
    [SerializeField] private BoxCollider2D slideCollider;
    private Animator anim;
    public GameObject player;
    [SerializeField] private float slideSpeed;
    private bool isGrounded;
    private bool isHit;

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = player.GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = pm.isGrounded();
        slideSpeed = pm.speed;
        isHit = pm.isHit;
        if (isHit == true)
        {
            anim.SetBool("slide", false);
        }
        if (Input.GetKeyDown(KeyCode.C) && isGrounded == true)
        {
            performSlide();
        }
    }

    void performSlide()
    {
        isSliding = true;
        anim.SetBool("slide", true);
        regularCollider.enabled = false;
        slideCollider.enabled = true;
        StartCoroutine("stopSlide");
    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("slide", false);
        regularCollider.enabled = true;
        slideCollider.enabled = false;
        isSliding = false;
    }
}
