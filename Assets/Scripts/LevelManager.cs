using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] enemigos; // Asigna Pinguino1, Pinguino2 y Pinguino3 desde el Inspector

    void Update()
    {
        if (TodosMuertos())
        {
            StartCoroutine(TransicionGanar());
        }
    }

    bool TodosMuertos()
    {
        foreach (GameObject e in enemigos)
        {
            if (e != null) return false;
        }
        return true;
    }

    IEnumerator TransicionGanar()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Oso N2"); 
    }
}
