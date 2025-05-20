using UnityEngine;

public class Rayo : MonoBehaviour
{
    public float velocidad = 40f;
    public float tiempoDeVida = 5f;
    public AudioClip nieve;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private bool yaChoco = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.linearVelocity = Vector2.down * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (yaChoco || PlayerLifeReyN4.juegoTerminado) return;

        if (other.CompareTag("Amber"))
        {
            yaChoco = true;

            PlayerLifeReyN4 amber = other.GetComponent<PlayerLifeReyN4>();
            if (amber != null)
            {
                amber.RecibirDanio();
            }

            if (nieve != null && audioSource != null)
            {
                audioSource.PlayOneShot(nieve);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                rb.linearVelocity = Vector2.zero;
                Destroy(gameObject, nieve.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}