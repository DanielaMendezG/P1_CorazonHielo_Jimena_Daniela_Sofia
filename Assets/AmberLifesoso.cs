using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmberLife_Oso : MonoBehaviour
{
    public int vidas = 2;
    public Image[] Vidas;

    private bool yaMurio = false;
    public static bool juegoTerminado = false;
    private bool puedeRecibirDanio = true;

    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        if (escenaActual == "Win N2" || escenaActual == "Lose N2")
        {
            this.enabled = false;
            return;
        }
    }

    public void RecibirDanio()
    {
        if (yaMurio || juegoTerminado || !puedeRecibirDanio) return;

        puedeRecibirDanio = false;
        Invoke("ReactivarDanio", 1f);

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

    void ReactivarDanio()
    {
        puedeRecibirDanio = true;
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

