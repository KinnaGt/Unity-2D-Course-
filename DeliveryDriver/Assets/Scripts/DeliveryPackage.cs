using UnityEngine;

public class DeliveryPackage : MonoBehaviour
{
    bool hasPackage;
    Color32 hasPackageColor = new Color32(162, 255, 126, 255);
    Color32 normalColor = new Color32(255, 255, 255, 255);


    SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, 0.5f);
            sprite.color = hasPackageColor;
        }
        if (other.tag == "Client" && hasPackage)
        {
            Debug.Log("Delivered Package ");
            hasPackage = false;
            sprite.color = normalColor;
        }
    }
}
