using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanar : MonoBehaviour
{
    public string siguienteNivel = "oso N2"; 
    public float tiempoAntesDeCambiar = 3f;  

    void Start()
    {
        
        PlayerLifes.juegoTerminado = true;

       
        GameObject amber = GameObject.FindWithTag("Amber");
        if (amber != null)
        {
            amber.SetActive(false);
        }

        
        GameObject[] balas = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject b in balas)
        {
            Destroy(b);
        }

        
        Invoke(nameof(CambiarEscena), tiempoAntesDeCambiar);
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(siguienteNivel);
    }
}
