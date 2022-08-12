
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player;
    [SerializeField] private float speed = 12f;
    private Rigidbody body;
    private PlayerMovement pm;
    private Rigidbody2D playerRB;
    private bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        pm = player.GetComponent<PlayerMovement>();
        playerRB = player.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        isHit = pm.isHit;
        if (isHit == false)
        {
            body.velocity = playerRB.velocity;

        }
        else
        {
            body.velocity = new Vector2(0, 0);
            this.enabled = false;
        }
        transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
    }
}
