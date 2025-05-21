using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifeReyN4 : MonoBehaviour
{
    public int vidas = 1;
    public Image[] Vidas;

    private bool yaMurio = false;
    public static bool juegoTerminado = false;

    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        if (escenaActual == "Win N4" || escenaActual == "Lose N4")
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
            SceneManager.LoadScene("Lose N4");
        }
    }

    public void GanarVida()
    {
        if (vidas < Vidas.Length)
        {
            Vidas[vidas].enabled = true;
            vidas++;
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
        else if (other.CompareTag("VidaExtra"))
        {
            GanarVida();
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        // Por ahora vacío
    }
}



