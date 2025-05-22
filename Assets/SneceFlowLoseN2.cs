using UnityEngine;
using UnityEngine.SceneManagement;


public class SneceFlowLoseN2 : MonoBehaviour
{
    public bool didPlayerWin = true;
    public string sceneNameToLoadIfEnd = "oso N2";
    void Start()
    {
        Invoke("DecideNextScene", 3f);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
