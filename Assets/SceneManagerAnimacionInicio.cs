using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SceneManagerAnimacionInicio : MonoBehaviour
{
    public string nombreEscenaSiguiente = "Inicio";
    public VideoPlayer videoPlayer;

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("No se encontró el componente VideoPlayer.");
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        SceneManager.LoadScene(nombreEscenaSiguiente);
    }
}
