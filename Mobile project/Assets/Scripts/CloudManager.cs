using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    [SerializeField] private GameObject[] cloudPrefabs;
    private float delay = 2;
    private static bool spawnClouds = true;
    private int[] cloudIndexs = { 0, 1, 2 };


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

    IEnumerator SpawnClouds()
    {
        // Only spawn clouds if the boolean spawnClouds is true
        while (spawnClouds)
        {
            System.Random random = new System.Random();
            int randomItem = random.Next(0, cloudIndexs.Length);

            // Instantiate Cloud Prefabs and then wait for specified delay, and then repeat
            Instantiate(cloudPrefabs[randomItem]);

            yield return new WaitForSeconds(delay);
        }
    }
}
