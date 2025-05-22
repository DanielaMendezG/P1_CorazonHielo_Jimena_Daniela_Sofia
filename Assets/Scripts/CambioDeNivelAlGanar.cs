using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanar : MonoBehaviour
{
    [Tooltip("Nombre de la escena que se cargar� al ganar.")]
    public string nombreEscenaVictoria = "Win N2";

    public void ActivarVictoria()
    {
        SceneManager.LoadScene(nombreEscenaVictoria);
    }
}
