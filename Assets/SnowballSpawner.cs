using UnityEngine;

public class SnowballSpawner : MonoBehaviour
{
    public GameObject bigSnowballPrefab;
    public float intervalo = 2f;
    public Vector2 direccion = new Vector2(-1f, -1f); // Ajusta para que caiga en diagonal

    void Start()
    {
        InvokeRepeating(nameof(LanzarBola), 1f, intervalo);
    }

    void LanzarBola()
    {
        GameObject bola = Instantiate(bigSnowballPrefab, transform.position, Quaternion.identity);
        BigSnowball bs = bola.GetComponent<BigSnowball>();
        if (bs != null)
        {
            bs.direccionCaida = direccion;
        }
    }
}
