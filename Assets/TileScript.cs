using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {

    public bool spawnGrid;

    public List<Vector3> spawnPoints = new List<Vector3>();
    public GameObject spawnPoint;
    public Transform gridStartPoint;
    public float gridX;
    public float gridY;

	// Use this for initialization
	void Start ()
    {
        if(spawnGrid)
        {
            SpawnGrid();
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

    public void GenerateSpawnList()
    {
        ObsticleSpawnPoint[] temp = GameObject.FindObjectsOfType<ObsticleSpawnPoint>();
        foreach (ObsticleSpawnPoint item in temp)
        {
            if(item.gameObject.tag != "GridStart")
            {
                spawnPoints.Add(item.gameObject.transform.position);
            }
        }
    }
}
