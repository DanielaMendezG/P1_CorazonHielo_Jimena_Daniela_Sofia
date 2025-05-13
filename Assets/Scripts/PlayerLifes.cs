using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{
    public int vidas = 3;
    public Image[] Vidas; 

    public void RecibirDanio()
    {
        vidas--;

        if (vidas >= 0)
        {
            Vidas[vidas].enabled = false; 
        }

        if (vidas <= 0)
        {
            SceneManager.LoadScene("Perdiste_pinguino"); // Cambia el nombre si tu escena se llama diferente
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            RecibirDanio();
        }
    }
}
