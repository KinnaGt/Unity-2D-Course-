using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    bool wasCollected = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && wasCollected)
        {
            wasCollected = false;
            Destroy(gameObject);
            FindObjectOfType<GameSession>().IncreaseScore(100);
            AudioSource.PlayClipAtPoint(coinPickupSFX, new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z));
        }
    }
}
