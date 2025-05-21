using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Bearlife : MonoBehaviour
{
    public int vida = 5;
    public GameObject efectoMuerte;

    public void RecibirDanio()
    {
        if (AmberLife_Oso.juegoTerminado) return; // Evita múltiples ejecuciones

        vida--;
        Debug.Log("Oso recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            StartCoroutine(TransicionGanar());
        }
    }

    IEnumerator TransicionGanar()
    {
        AmberLife_Oso.juegoTerminado = true;

        if (efectoMuerte != null)
        {
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        yield return new WaitForSeconds(1f); // Espera para que se vea la animación/muerte

        SceneManager.LoadScene("Win N2");
    }
}