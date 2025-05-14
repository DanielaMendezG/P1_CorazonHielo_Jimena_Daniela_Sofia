using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoDeVida = 5f;

    public AudioClip fuego;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    private bool yaChoco = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.linearVelocity = Vector2.up * velocidad;
        Destroy(gameObject, tiempoDeVida); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (yaChoco) return;

        Debug.Log("Fuego chocó con: " + other.name);

        if (other.CompareTag("Enemy"))
        {
            yaChoco = true;

            EnemyLifes enemy = other.GetComponent<EnemyLifes>();
            if (enemy != null)
            {
                enemy.RecibirDanio(); 
            }

            if (fuego != null && audioSource != null)
            {
                audioSource.PlayOneShot(fuego);
            }

            
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            rb.linearVelocity = Vector2.zero;

            Destroy(gameObject, fuego.length);
        }
        else if (!other.CompareTag("Amber"))
        {
            Destroy(gameObject);
        }
    }
}

