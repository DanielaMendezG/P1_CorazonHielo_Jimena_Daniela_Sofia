using UnityEngine;

public class CrystalBounce : MonoBehaviour
{
    public GameObject efectoRompimiento; // opcional: efecto visual

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                // Rebote
                Vector2 rebote = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
                rb.linearVelocity = rebote;
            }

            // Destruir el cristal después del rebote
            if (efectoRompimiento != null)
            {
                Instantiate(efectoRompimiento, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }
}


