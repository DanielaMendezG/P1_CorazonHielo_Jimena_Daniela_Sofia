using UnityEngine;

public class BigSnowball : MonoBehaviour
{
    public Vector2 direccionCaida = new Vector2(-1f, -1f); // Direcci�n inicial
    public float velocidad = 4f;
    public float tiempoDeVida = 5f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direccionCaida.normalized * velocidad;
        }

        Destroy(gameObject, tiempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball") || other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}


