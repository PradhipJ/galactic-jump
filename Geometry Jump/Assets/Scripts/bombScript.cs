
using UnityEngine;

public class bombScript : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("playerHit", true);
            Destroy(gameObject, 1f);
        }
    }
}
