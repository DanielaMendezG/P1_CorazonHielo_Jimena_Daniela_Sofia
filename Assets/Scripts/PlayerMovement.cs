using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject Boladefuego;
    public Transform puntodedisparoarriba;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        Debug.Log("PlayerController: Iniciado");
    }

    void Update()
    {
        Debug.Log("PlayerController: Update ejecutándose");

        if (AmberLifesoso.juegoTerminado)
        {
            Debug.Log("Juego terminado, no se puede mover Amber");
            return;
        }

        moveX = Input.GetAxisRaw("Horizontal");
        Debug.Log("Input Horizontal: " + moveX);

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        animator.SetBool("IsWalking", moveX != 0);
        animator.SetFloat("MoveX", moveX);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("IsShooting");
            Debug.Log("Amber disparó");
            Invoke(nameof(DispararArriba), 0.2f);
        }
    }

    void DispararArriba()
    {
        if (Boladefuego == null || puntodedisparoarriba == null)
        {
            Debug.LogWarning("Boladefuego o punto de disparo no asignado.");
            return;
        }

        GameObject bullet = Instantiate(Boladefuego, puntodedisparoarriba.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = Vector2.up * 10f;
        }

        Debug.Log("Disparo hacia arriba ejecutado");
    }
}
