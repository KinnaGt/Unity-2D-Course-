using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float resetCooldown = 0.5f;
    [SerializeField] ParticleSystem effect;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground")
        {
            FindObjectOfType<PlayerController>().DisableControls();
            effect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ResetScene", resetCooldown);
        }
    }
    private void ResetScene()
    {
        SceneManager.LoadScene(0);
    }
}
