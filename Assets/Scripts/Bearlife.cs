using UnityEngine;
using UnityEngine.SceneManagement;

public class Bearlife : MonoBehaviour
{
    public int vida = 5;
    public GameObject efectoMuerte;

    public void RecibirDanio()
    {
        vida--;
        Debug.Log("Oso recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        if (efectoMuerte != null)
        {
            Instantiate(efectoMuerte, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // elimina el oso

        // Cambia esto por la escena que corresponda al ganar
        SceneManager.LoadScene("Win N1");
    }
}
