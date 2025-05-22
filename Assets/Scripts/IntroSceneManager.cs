using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public string nombreNivelSiguiente = "pinguinos N1"; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nombreNivelSiguiente);
        }
    }
}
