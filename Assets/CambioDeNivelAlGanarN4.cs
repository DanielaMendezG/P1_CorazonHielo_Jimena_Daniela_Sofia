using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanarN4 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public string siguienteNivel = "escena final";
    public float tiempoAntesDeCambiar = 6f;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
