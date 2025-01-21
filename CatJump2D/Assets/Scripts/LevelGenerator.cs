using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms;
    public float levelWidth = 3f;
    public float minY = 1.3f;
    public float maxY = 3f;

    private Vector3 _spawnPosition = new Vector3();

    void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        _spawnPosition.y += Random.Range(minY, maxY);
        _spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(platformPrefab, _spawnPosition, Quaternion.identity);
    }
}
