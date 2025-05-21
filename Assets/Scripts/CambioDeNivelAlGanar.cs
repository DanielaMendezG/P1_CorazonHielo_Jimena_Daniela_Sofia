using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanar : MonoBehaviour
{
    public float tiempoAntesDeCambiar = 3f;
    public string siguienteNivel = "rey N3";

    // Asegúrate de que este método exista y sea público
    public void ActivarVictoria()
    {
        Debug.Log("¡Victoria activada!");

        PlayerLifes.juegoTerminado = true;

        GameObject[] balas = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bala in balas)
        {
            Destroy(bala);
        }

        Invoke(nameof(CambiarEscena), tiempoAntesDeCambiar);
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(siguienteNivel);
    }
}
