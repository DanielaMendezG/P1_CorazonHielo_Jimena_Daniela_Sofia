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
    private int direccion = 1; // 1 = derecha, -1 = izquierda

    private float bordeIzquierdo;
    private float bordeDerecho;

    private bool estaDisparando = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // Bordes visibles de la cámara para limitar movimiento
        Camera cam = Camera.main;
        bordeIzquierdo = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + 0.5f;
        bordeDerecho = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - 0.5f;

        // Repetir disparo automático cada cierto tiempo
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
        // Mover oso horizontalmente
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);

        // Animaciones caminar según dirección
        anim.SetBool("isWalkingRight", direccion == 1);
        anim.SetBool("isWalkingLeft", direccion == -1);

        // Cambiar dirección si toca bordes
        if ((direccion == 1 && transform.position.x >= bordeDerecho) ||
            (direccion == -1 && transform.position.x <= bordeIzquierdo))
        {
            direccion *= -1;

            // Voltear escala en X para que el oso mire hacia la dirección correcta
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

        // Parar movimiento y animaciones de caminar
        rb.linearVelocity = Vector2.zero;
        anim.SetBool("isWalkingRight", false);
        anim.SetBool("isWalkingLeft", false);

        // Activar animación de disparo (trigger)
        anim.SetTrigger("ososhooting");

        // Esperar 0.4 segundos para que se vea la animación antes de disparar
        yield return new WaitForSeconds(0.4f);

        // Instanciar spikeball y darle velocidad hacia abajo
        if (spikeball != null && puntoDisparo != null)
        {
            GameObject bola = Instantiate(spikeball, puntoDisparo.position, Quaternion.identity);
            Rigidbody2D rbBola = bola.GetComponent<Rigidbody2D>();
            if (rbBola != null)
            {
                rbBola.linearVelocity = Vector2.down * 5f;
            }
        }

        // Esperar un poco antes de permitir movimiento de nuevo
        yield return new WaitForSeconds(0.6f);

        estaDisparando = false;
    }
}