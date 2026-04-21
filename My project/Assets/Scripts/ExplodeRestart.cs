using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("danger"))
        {
            Explode();
        }
    }

    void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        Invoke("RestartGame", 1f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ExplodeEfect()
    {
        Debug.Log("BOOM"); // ← добавь это

        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        Invoke("RestartGame", 1f);
    }
}