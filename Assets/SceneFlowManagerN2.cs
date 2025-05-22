using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class SceneFlowManagerN2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] enemigos;

    private bool nivelGanado = false;
    void Start()
    {
        AmberLife_Oso.juegoTerminado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AmberLife_Oso.juegoTerminado) return;

        if (TodosMuertos())
        {
            AmberLife_Oso.juegoTerminado = true;
            Debug.Log("Todos los enemigos están muertos");
            // Ya no cambiamos de escena aquí, Bearlife lo hace.
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
        PlayerLifes.juegoTerminado = true;


        GameObject[] balasEnemigas = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bala in balasEnemigas)
        {
            Destroy(bala);
        }

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Win N2");
    }
}
