using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoDeVida = 5f;
    public AudioClip nieve;

    private AudioSource audioSource;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.linearVelocity = Vector2.down * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Amber"))
        {
            PlayerLifes jugador = other.GetComponent<PlayerLifes>();
            if (jugador != null)
            {
                jugador.RecibirDanio();
            }

            if (nieve != null && audioSource != null)
            {
                audioSource.PlayOneShot(nieve);
            }

            Destroy(gameObject);
        }
        else if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
