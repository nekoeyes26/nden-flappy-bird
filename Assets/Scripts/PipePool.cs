using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public int pipePoolSize = 5;
    public GameObject pipePrefab;
    public float spawnRate = 4f;
    public float minHeight = -1f;
    public float maxHeight = 2f;
    private GameObject[] pipe;
    private Vector2 objectPoolPosition = new Vector2(-10f, -15f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentPipe = 0;
    // Start is called before the first frame update
    void Start()
    {
        InitializePipes();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        if (timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(minHeight, maxHeight);
            pipe[currentPipe].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentPipe++;
            if (currentPipe >= pipePoolSize)
            {
                currentPipe = 0;
            }
        }
    }
    void InitializePipes()
    {
        pipe = new GameObject[pipePoolSize];

        for (int i = 0; i < pipePoolSize; i++)
        {
            pipe[i] = Instantiate(pipePrefab, objectPoolPosition, Quaternion.identity);
        }
    }
    public void Restart()
    {
        // Reset the pipes to their initial positions
        for (int i = 0; i < pipePoolSize; i++)
        {
            pipe[i].transform.position = objectPoolPosition;
        }

        // Reset variables
        timeSinceLastSpawned = 0;
        currentPipe = 0;
    }
}
