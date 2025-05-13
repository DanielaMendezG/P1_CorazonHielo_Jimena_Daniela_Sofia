using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoDeVida = 3f;

    public AudioClip fuego;
    private AudioSource audioSource;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.linearVelocity = Vector2.up * velocidad;

        Destroy(gameObject, 5f); // 🔥 Se destruye sola después de 5 segundos
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("🔥 Fuego chocó con: " + other.name);

        if (other.CompareTag("Enemy"))
        {
            EnemyLifes enemy = other.GetComponent<EnemyLifes>();
            if (enemy != null)
            {
                enemy.RecibirDanio(); // Descuenta vida
            }

            if (fuego != null && audioSource != null)
            {
                audioSource.PlayOneShot(fuego);
            }

            Destroy(gameObject); // Desaparece la bola
        }
        else if (!other.CompareTag("Amber"))
        {
            Destroy(gameObject); // Si choca con otra cosa, también desaparece
        }
    }
}
