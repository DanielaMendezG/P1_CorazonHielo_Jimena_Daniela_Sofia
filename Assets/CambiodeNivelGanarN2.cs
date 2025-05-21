using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanarN2 : MonoBehaviour
{
    public string siguienteNivel = "rey N3";
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
