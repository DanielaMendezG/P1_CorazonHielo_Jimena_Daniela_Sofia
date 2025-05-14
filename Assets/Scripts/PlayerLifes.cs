using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{
    public int vidas = 3;
    public Image[] Vidas;

    private bool yaMurio = false;
    public static bool juegoTerminado = false;

    void Start()
    {
        
        string escenaActual = SceneManager.GetActiveScene().name;
        if (escenaActual == "Win N1" || escenaActual == "Lose N1")
        {
            this.enabled = false;
            return;
        }
    }

    public void RecibirDanio()
    {
        if (yaMurio || juegoTerminado) return;

        vidas = Mathf.Clamp(vidas - 1, 0, Vidas.Length);

        if (vidas < Vidas.Length && vidas >= 0)
        {
            Vidas[vidas].enabled = false;
        }

        if (vidas <= 0)
        {
            yaMurio = true;
            SceneManager.LoadScene("Lose N1");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (juegoTerminado || yaMurio) return;

        if (other.CompareTag("EnemyBullet"))
        {
            Destroy(other.gameObject);
            RecibirDanio();
        }
    }
}

