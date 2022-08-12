using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private PlayerMovement pm;
    [SerializeField] private float attackCooldown;
    public bool isAttacking = false;
    private float cooldownTimer = Mathf.Infinity;

    void Start()
    {
        anim = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCooldown && pm.canShoot())
        {
            Attack();
        }
        else
        {
            isAttacking = false;
        }
        cooldownTimer += Time.deltaTime;
    }

    void Attack()
    {
        isAttacking = true;
        anim.SetTrigger("attack");
        cooldownTimer = 0;
    }
}
