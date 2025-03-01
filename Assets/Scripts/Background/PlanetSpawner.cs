using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] float minX = -5f;
    [SerializeField] float maxX = 5f;
    [SerializeField] float yPos = 12.5f;
    [SerializeField] float duration = 10f;

    [Header("Planets")]
    [SerializeField] GameObject[] planetPrefabs;


    private void Start()
    {
        StartCoroutine(SpawnPlanet());
    }

    
    IEnumerator SpawnPlanet()
    {
        while (true)
        {
            float rnd = Random.Range(minX, maxX);
            int index = Random.Range(0, planetPrefabs.Length);
            Vector3 pos = new Vector3(rnd, yPos, 0);
            GameObject planet = Instantiate(planetPrefabs[index], pos, Quaternion.identity);
            Destroy(planet, 20f);

            yield return new WaitForSeconds(duration);
        }
    }
}
