using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public bool spawnGrid;
    public bool firstRun;

    public float gridX;
    public float gridY;
    public GameObject spawnPoint;
    public Transform gridStartPoint;
    List<Transform> spawnPoints = new List<Transform>();
    public List<Transform> groundPoints = new List<Transform>();
    public List<Transform> airPoints = new List<Transform>();
    public List<GameObject> groundObsticles = new List<GameObject>();
    public List<GameObject> airObsticles = new List<GameObject>();

	// Use this for initialization
	void Start ()
    {
        if(spawnGrid)
        {
            SpawnGrid();
        } else
        {
            GenerateSpawnList();
        }

        if(firstRun)
        {
            GenerateObstacles();
        }

    }
	
	// Update is called once per frame
	void Update () {

	}

    void SpawnGrid()
    {
        int finalGridX = (int)gridX + 1;
        int finalGridY = ((int)gridY + 1) / 2;

        for (int y = 0; y < finalGridY; y++)
        {
            for (int x = 0; x < finalGridX; x++)
            {
                Vector3 tempPos = new Vector3((gridStartPoint.position.x + 0.5f) + x, (gridStartPoint.position.y + y + 0.5f), 0f);
                Instantiate(spawnPoint, tempPos, Quaternion.identity);
            }
        }
    }

    void GenerateSpawnList()
    {
        foreach (Transform item in transform.GetComponentsInChildren<Transform>())
        {
            if(item.gameObject.tag != "GridStart")
            {
                spawnPoints.Add(item);
            }
        }

        foreach (Transform item in spawnPoints)
        {
            RaycastHit2D hit = Physics2D.Raycast(item.position, Vector2.down);
            if (hit.collider != null && hit.collider.gameObject.tag == "Tile")
            {
                if(hit.distance < 3f)
                {
                    groundPoints.Add(item);
                } else if (hit.distance >= 8f && hit.distance <= 12f)
                {
                    airPoints.Add(item);
                }
            }
        }
    }

    public void ClearObstacles()
    {
        foreach (Transform item in transform.GetComponentsInChildren<Transform>())
        {
            if(item.gameObject.tag == "Obstacle")
            {
                Destroy(item);
            }
        }
    }

    public void GenerateObstacles()
    {
        ClearObstacles();
        int numObstacles = (int)Random.Range(1f, 10f);
        int floatObstacles = (int)Random.Range(0f, numObstacles);
        Transform SpawnPoint = null;
        numObstacles = numObstacles - floatObstacles;
        for (int i = 0; i < floatObstacles; i++)
        {
            Transform tempSpawnPoint = airPoints[Random.Range(0, airPoints.Count - 1)];
            while (tempSpawnPoint == SpawnPoint)
            {
                tempSpawnPoint = airPoints[Random.Range(0, airPoints.Count - 1)];
            }
            if (tempSpawnPoint != SpawnPoint)
            {
                SpawnPoint = tempSpawnPoint;
                Instantiate(airObsticles[Random.Range(0, airObsticles.Count - 1)], SpawnPoint.position, Quaternion.identity, transform);
            }
        }

        for (int i = 0; i < numObstacles; i++)
        {
            Transform tempSpawnPoint = groundPoints[Random.Range(0, groundPoints.Count - 1)];
            while (tempSpawnPoint == SpawnPoint)
            {
                tempSpawnPoint = groundPoints[Random.Range(0, groundPoints.Count - 1)];
            }
            if (tempSpawnPoint != SpawnPoint)
            {
                SpawnPoint = tempSpawnPoint;
                Instantiate(airObsticles[Random.Range(0, groundObsticles.Count - 1)], SpawnPoint.position, Quaternion.identity, transform);
            }
        }
    }
}
