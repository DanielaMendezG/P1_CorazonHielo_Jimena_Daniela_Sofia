using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLifeRey : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int vidas = 1;
    public Image[] Vidas;

    private bool yaMurio = false;
    public static bool juegoTerminado = false;
    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;
        if (escenaActual == "Win N3" || escenaActual == "Lose N3")
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
            SceneManager.LoadScene("Lose N3");
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
