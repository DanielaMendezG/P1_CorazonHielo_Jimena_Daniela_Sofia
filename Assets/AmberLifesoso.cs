using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmberLife_Oso : MonoBehaviour
{
    public int vidas = 2;
    public Image[] Vidas;

    private bool yaMurio = false;
    public static bool juegoTerminado = false;

    void Start()
    {
        juegoTerminado = false;
    }

    public void RecibirDanio()
    {
        if (yaMurio || juegoTerminado) return;

        vidas = Mathf.Clamp(vidas - 1, 0, Vidas.Length);

        //if (vidas < Vidas.Length && Vidas[vidas] != null)
        //{
           // Vidas[vidas].enabled = false;
        //}

        if (vidas <= 0)
        {
            yaMurio = true;
            juegoTerminado = true;

            // Ir a escena de derrota
            SceneManager.LoadScene("Lose N2");
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


