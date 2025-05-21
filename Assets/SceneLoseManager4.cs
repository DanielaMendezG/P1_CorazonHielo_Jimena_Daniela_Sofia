using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseTransition : MonoBehaviour
{
    void Start()
    {
        Invoke("VolverNivelAnterior", 2f);
    }

    void VolverNivelAnterior()
    {
        SceneManager.LoadScene("rey N3"); // cambia a tu nivel anterior real si tiene otro nombre
    }
}