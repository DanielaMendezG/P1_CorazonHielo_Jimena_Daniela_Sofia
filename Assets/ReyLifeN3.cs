using UnityEngine;
using UnityEngine.SceneManagement;

public class ReyLifeN3 : MonoBehaviour
{
    public int vida = 4;
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
            SceneManager.LoadScene("Win N3"); // esta es la escena correcta para este nivel
        }
    }
}
