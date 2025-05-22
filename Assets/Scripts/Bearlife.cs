using UnityEngine;
using UnityEngine.SceneManagement;

public class Bearlife : MonoBehaviour
{
    public int vida = 5;
    public GameObject efectoMuerte;

    public void RecibirDanio()
    {
        vida--;
        Debug.Log("Rey recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            if (efectoMuerte != null)
            {
                Instantiate(efectoMuerte, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
            PlayerLifeRey.juegoTerminado = true;
            SceneManager.LoadScene("Win N2"); // esta es la escena correcta para este nivel
        }
    }
}