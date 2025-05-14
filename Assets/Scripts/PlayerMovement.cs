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
    }

    void Update()
    {
        
        moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        
        animator.SetBool("IsWalking", moveX != 0);
        animator.SetFloat("MoveX", moveX);

       
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            animator.SetTrigger("IsShooting");
            Invoke("DispararArriba", 0.2f);
        }
    }

    void DispararArriba()
    {
        if (Boladefuego == null || puntodedisparoarriba == null)
        {
            Debug.LogWarning("Prefab o punto de disparo arriba no asignado.");
            return;
        }

        GameObject bullet = Instantiate(Boladefuego, puntodedisparoarriba.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            bulletRb.linearVelocity = Vector2.up * 10f;
        }

        Debug.Log("Amber disparó fuego hacia ARRIBA");
    }
}
