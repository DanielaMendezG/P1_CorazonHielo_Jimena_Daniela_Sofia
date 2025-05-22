using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public string escenaReintento = "pinguinos N1";
    public float tiempoEspera = 3f;

    void Start()
    {
        Invoke(nameof(ReintentarNivel), tiempoEspera);
    }

    void ReintentarNivel()
    {
        SceneManager.LoadScene(escenaReintento);
    }
}







