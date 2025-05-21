using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Amber"))
        {
            PlayerLifeReyN4 amberVida = other.GetComponent<PlayerLifeReyN4>();
            if (amberVida != null)
            {
                amberVida.GanarVida();
            }

            Destroy(gameObject); // Desaparece el corazón
        }
    }
}

