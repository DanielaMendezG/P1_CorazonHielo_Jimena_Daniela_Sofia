using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AmberLife_Oso : MonoBehaviour
{
    public int vidas = 2;
    public Image[] Vidas;

    private bool yaMurio = false;
    private bool puedeSerDaniado = true; 

    public static bool juegoTerminado = false;

    void Start()
    {
        juegoTerminado = false;
    }

    public void RecibirDanio()
    {
        if (yaMurio || juegoTerminado || !puedeSerDaniado) return;

        puedeSerDaniado = false; 
        Invoke("ActivarDano", 0.5f); 

        vidas = Mathf.Clamp(vidas - 1, 0, Vidas.Length);

        

        if (vidas <= 0)
        {
            yaMurio = true;
            juegoTerminado = true;
            SceneManager.LoadScene("Lose N2");
        }
    }

    private void ActivarDano() 
    {
        puedeSerDaniado = true;
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
