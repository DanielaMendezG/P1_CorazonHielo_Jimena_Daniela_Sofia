using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFlowManagerN2 : MonoBehaviour
{
    public GameObject[] enemigos;

    void Start()
    {
        AmberLifesoso.juegoTerminado = false;
    }

    void Update()
    {
        if (AmberLifesoso.juegoTerminado) return;

        if (enemigos == null || enemigos.Length == 0) return; // ← AÑADIDO

        if (TodosMuertos())
        {
            AmberLifesoso.juegoTerminado = true;
            Debug.Log("Todos los enemigos están muertos");
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
        AmberLifesoso.juegoTerminado = true;

        GameObject[] balasEnemigas = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bala in balasEnemigas)
        {
            Destroy(bala);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Win N2");
    }
}
