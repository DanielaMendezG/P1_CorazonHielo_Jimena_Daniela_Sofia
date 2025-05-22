using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeNivelAlGanar : MonoBehaviour
{
    [Tooltip("Nombre de la escena que se cargará al ganar.")]
    public string nombreEscenaVictoria = "Win N2";

    public void ActivarVictoria()
    {
        SceneManager.LoadScene(nombreEscenaVictoria);
    }
}
