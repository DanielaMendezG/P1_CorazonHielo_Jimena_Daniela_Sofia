using UnityEngine;

public class CorazonSpawner : MonoBehaviour
{
    public GameObject prefabCorazon;
    public Transform[] posicionesSpawn;
    public float tiempoInicial = 5f;

    void Start()
    {
        Invoke(nameof(GenerarCorazon), tiempoInicial);
    }

    void GenerarCorazon()
    {
        if (posicionesSpawn.Length == 0) return;

        int indice = Random.Range(0, posicionesSpawn.Length);
        Instantiate(prefabCorazon, posicionesSpawn[indice].position, Quaternion.identity);
    }
}

