using UnityEngine;

public class Driver : MonoBehaviour
{
    float horizontalSpeed = 300;
    float moveSpeed = 20f;
    float slowSpeed = 15f;
    float bostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalSteer = Input.GetAxis("Horizontal") * horizontalSpeed * Time.deltaTime;
        float verticalSteer = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -horizontalSteer);
        transform.Translate(0, verticalSteer, 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost")
        {
            moveSpeed = bostSpeed;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
}
