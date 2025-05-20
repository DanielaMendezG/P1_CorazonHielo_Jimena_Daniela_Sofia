using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanarN3 : MonoBehaviour
{
    public string siguienteNivel = "rey N4";
    public float tiempoAntesDeCambiar = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
