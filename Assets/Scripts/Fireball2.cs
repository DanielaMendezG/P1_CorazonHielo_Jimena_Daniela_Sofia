using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Solo daña si el objeto tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            Bearlife oso = other.GetComponent<Bearlife>();
            if (oso != null)
            {
                oso.RecibirDanio();
            }

            Destroy(gameObject); // Solo se destruye si golpea al enemigo
        }
    }
}
