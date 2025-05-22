using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerAnimacionInicio : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string nombreNivelSiguiente = "pinguinos N1";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(nombreNivelSiguiente);
            }
        }
    }
}
