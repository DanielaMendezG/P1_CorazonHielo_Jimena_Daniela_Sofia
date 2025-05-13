using UnityEngine;

public class EnemyLifes : MonoBehaviour
{
    public int vida = 2; // Puedes ajustar la vida en el Inspector

    public void RecibirDanio()
    {
        vida--;

        Debug.Log("🐧 ¡Pingüino golpeado! Vida restante: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject); // El pingüino desaparece
        }
    }
}
