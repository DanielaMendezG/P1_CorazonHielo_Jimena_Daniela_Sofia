using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFlowManager : MonoBehaviour
{
    public bool didPlayerWin = true;
    public string sceneNameToLoadIfEnd = "Inicio"; // Nombre de la escena de inicio

    void Start()
    {
        Invoke("DecideNextScene", 2f);
    }

    void DecideNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (didPlayerWin)
        {
            int nextLevelIndex = currentSceneIndex + 1;
            if (nextLevelIndex < totalScenes)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                // Si no hay más niveles, vuelve al inicio
                SceneManager.LoadScene(sceneNameToLoadIfEnd);
            }
        }
        else
        {
            int retryLevelIndex = currentSceneIndex - 2;
            if (retryLevelIndex >= 0)
            {
                SceneManager.LoadScene(retryLevelIndex);
            }
            else
            {
                // Si no hay nivel anterior (o es el último y pierde), vuelve al inicio
                SceneManager.LoadScene(sceneNameToLoadIfEnd);
            }
        }
    }
}