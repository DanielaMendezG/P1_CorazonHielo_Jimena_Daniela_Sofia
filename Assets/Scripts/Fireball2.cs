using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Bearlife oso = other.GetComponent<Bearlife>();
            if (oso != null)
            {
                oso.RecibirDanio();
            }

            Destroy(gameObject); // destruye la bola de fuego al impactar
        }
    }
}
