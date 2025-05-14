using UnityEngine;

public class EnemyLifes : MonoBehaviour
{
    public int vida = 2; 

    public void RecibirDanio()
    {
        vida--;

        Debug.Log("¡Pingüino golpeado! Vida restante: " + vida);

        if (vida <= 0)
        {
            Destroy(gameObject); 
        }
    }
}
