using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneFlowManagerN3 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool didPlayerWin = true;
    public string sceneNameToLoadIfEnd = "rey N4";
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
     //no necesario por ahora//
    }
}
