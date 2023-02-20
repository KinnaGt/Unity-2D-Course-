using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float resetCooldown = 2;
    [SerializeField] ParticleSystem effect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
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
