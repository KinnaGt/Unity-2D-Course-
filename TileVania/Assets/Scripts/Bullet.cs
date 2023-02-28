using UnityEngine;

public class Bullet : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    [SerializeField] float bulletSpeed = 10f;
    float xSpeed;
    PlayerMovement playerMovement;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        xSpeed = playerMovement.transform.localScale.x * bulletSpeed;
    }


    void Update()
    {
        rigidbody2D.velocity = new Vector2(xSpeed, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

}
