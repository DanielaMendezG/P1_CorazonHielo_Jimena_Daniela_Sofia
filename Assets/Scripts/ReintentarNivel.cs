using UnityEngine;
using UnityEngine.SceneManagement;

public class ReintentarNivel : MonoBehaviour
{
    public string nombreDelNivel = "pinguinos N1";

    public void Reintentar()
    {
        SceneManager.LoadScene(nombreDelNivel);
    }
}
