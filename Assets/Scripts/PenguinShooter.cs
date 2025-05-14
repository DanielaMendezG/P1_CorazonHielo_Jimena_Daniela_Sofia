using UnityEngine;

public class PenguinShooter : MonoBehaviour
{
    public GameObject boladenieve;       
    public Transform puntodedisparo;     
    public float tiempoEntreDisparos = 2f;
    public float fuerzaDisparo = 5f;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        InvokeRepeating("Disparar", 1f, tiempoEntreDisparos);
    }

    void Disparar()
    {
        if (anim != null)
        {
            anim.SetTrigger("IsShooting");
        }

        Invoke("InstanciarBola", 0.4f); 
    }

    void InstanciarBola()
    {
        if (boladenieve == null)
        {
            Debug.LogWarning(" boladenieve no está asignado en el Inspector");
            return;
        }

        if (puntodedisparo == null)
        {
            Debug.LogWarning(" puntodedisparo no está asignado en el Inspector");
            return;
        }

        GameObject bola = Instantiate(boladenieve, puntodedisparo.position, Quaternion.identity);
        Debug.Log(" Bola de nieve creada en " + puntodedisparo.position);

        Rigidbody2D rb = bola.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * fuerzaDisparo;
        }
        else
        {
            Debug.LogWarning(" La bola de nieve no tiene Rigidbody2D.");
        }
    }
}
