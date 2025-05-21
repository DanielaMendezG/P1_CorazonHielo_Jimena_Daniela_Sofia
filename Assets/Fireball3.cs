using UnityEngine;

public class Fireball3 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Fuego chocó con: " + other.name);

        if (other.CompareTag("Enemy"))
        {
            ReyLifeN3 rey = other.GetComponent<ReyLifeN3>();
            if (rey != null)
            {
                rey.RecibirDanio();
            }

            Destroy(gameObject);
        }
    }
}
