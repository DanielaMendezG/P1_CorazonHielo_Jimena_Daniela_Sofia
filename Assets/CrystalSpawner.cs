using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    public GameObject crystalPrefab;
    public float intervalo = 5f;

    public Transform[] posiciones;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCrystal), 1f, intervalo);
    }

    void SpawnCrystal()
    {
        int index = Random.Range(0, posiciones.Length);
        Instantiate(crystalPrefab, posiciones[index].position, Quaternion.identity);
    }
}

