using UnityEngine;

public class Spikeball : MonoBehaviour
{
    public float velocidad = 5f;
    public float tiempoDeVida = 5f;
    public AudioClip sonidoPincho;

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
        if (yaChoco || AmberLife_Oso.juegoTerminado) return;

        if (other.CompareTag("Amber"))
        {
            yaChoco = true;

            AmberLife_Oso jugador = other.GetComponent<AmberLife_Oso>();
            if (jugador != null)
            {
                jugador.RecibirDanio();
            }

            if (sonidoPincho != null && audioSource != null)
            {
                audioSource.PlayOneShot(sonidoPincho);
                GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<Collider2D>().enabled = false;
                rb.linearVelocity = Vector2.zero;
                Destroy(gameObject, sonidoPincho.length);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (!other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
