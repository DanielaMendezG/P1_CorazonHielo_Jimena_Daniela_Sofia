using UnityEngine;

public class HieloResistente : MonoBehaviour
{
    public int golpesNecesarios = 2; // Número de golpes para destruirlo
    private int golpesRecibidos = 0;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boladefuego"))
        {
            golpesRecibidos++;
            if (spriteRenderer != null && golpesRecibidos == 1)
            {
                spriteRenderer.color = Color.cyan;
            }

            // Si recibió todos los golpes, destruye el hielo
            if (golpesRecibidos >= golpesNecesarios)
            {
                Destroy(gameObject);
            }
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
