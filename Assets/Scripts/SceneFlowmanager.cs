using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    void Start()
    {
        string escenaActual = SceneManager.GetActiveScene().name;

        if (escenaActual == "Win N2")
        {
            Invoke("CargarNivelSiguiente", 3f);
        }
        else if (escenaActual == "Lose N2")
        {
            Invoke("ReintentarNivel", 3f);
        }
    }

    void CargarNivelSiguiente()
    {
        SceneManager.LoadScene("rey N3");
    }

    void ReintentarNivel()
    {
        SceneManager.LoadScene("pinguinos N1");
    }
}






