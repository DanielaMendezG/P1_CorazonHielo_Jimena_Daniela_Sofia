using UnityEngine;
using System.Collections;

public class BearShooter : MonoBehaviour
{
    public GameObject spikeball;
    public Transform puntoDisparo;
    public float velocidad = 2f;
    public float tiempoEntreDisparos = 3f;

    private Animator anim;
    private Rigidbody2D rb;
    private int direccion = 1;

    private float bordeIzquierdo;
    private float bordeDerecho;

    private bool estaDisparando = false;

    public int vida = 5;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Camera cam = Camera.main;
        bordeIzquierdo = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.5f;
        bordeDerecho = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.5f;

        InvokeRepeating("IntentarDisparar", 1f, tiempoEntreDisparos);
    }

    void Update()
    {
        if (!estaDisparando)
        {
            Mover();
        }
    }

    void Mover()
    {
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);

        anim.SetBool("isWalkingRight", direccion == 1);
        anim.SetBool("isWalkingLeft", direccion == -1);

        if ((direccion == 1 && transform.position.x >= bordeDerecho) ||
            (direccion == -1 && transform.position.x <= bordeIzquierdo))
        {
            direccion *= -1;

            Vector3 escala = transform.localScale;
            escala.x = Mathf.Abs(escala.x) * direccion;
            transform.localScale = escala;
        }
    }

    public void IntentarDisparar()
    {
        if (!estaDisparando)
            StartCoroutine(Disparar());
    }

    IEnumerator Disparar()
    {
        estaDisparando = true;

        rb.linearVelocity = Vector2.zero;
        anim.SetBool("isWalkingRight", false);
        anim.SetBool("isWalkingLeft", false);

        anim.SetTrigger("ososhooting");

        yield return new WaitForSeconds(0.4f);

        if (spikeball != null && puntoDisparo != null)
        {
            GameObject bola = Instantiate(spikeball, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            if (rbBola != null)
            {
                rbBola.linearVelocity = Vector2.down * 5f;
            }
        }

        yield return new WaitForSeconds(0.6f);

        estaDisparando = false;
    }

    public void RecibirDanio()
    {
        vida--;
        Debug.Log("El jefe recibió daño. Vida restante: " + vida);

        if (vida <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        Destroy(gameObject);

        CambioDeNivelAlGanar cambio = FindFirstObjectByType<CambioDeNivelAlGanar>();
        if (cambio != null)
        {
            cambio.ActivarVictoria();
        }
        else
        {
            Debug.LogWarning("No se encontró el script CambioDeNivelAlGanar en la escena.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball"))
        {
            RecibirDanio();
            Destroy(other.gameObject);
        }
    }
}
