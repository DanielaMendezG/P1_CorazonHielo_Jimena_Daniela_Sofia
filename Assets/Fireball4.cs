using UnityEngine;

public class Fireball4 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ReyLifeN4 rey = other.GetComponent<ReyLifeN4>();
            if (rey != null)
            {
                rey.RecibirDanio();
            }

            Destroy(gameObject); // destruye la bola de fuego al impactar
        }
    }
}
