using UnityEngine;

public class Rayo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad = 40f;
    public float tiempoDeVida = 5f;
    public AudioClip nieve;

    private AudioSource audioSource;
    private Rigidbody2D rb;
    private bool yaChoco = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.linearVelocity = Vector2.down * velocidad;
        Destroy(gameObject, tiempoDeVida);
    }

    // Update is called once per frame
    
    void Update()
    {
        
    }
}
