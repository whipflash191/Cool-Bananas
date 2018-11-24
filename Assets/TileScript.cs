using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
    BoxCollider2D spawnBounds;
    PolygonCollider2D cantSpawn; 

    public GameObject spawnPoint;
    public Transform gridStartPoint;

	// Use this for initialization
	void Start ()
    {
        spawnBounds = GetComponent<BoxCollider2D>();
        cantSpawn = GetComponent<PolygonCollider2D>();
        SpawnGrid();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnGrid()
    {
        int gridX = (int)spawnBounds.size.x + 1;
        int gridY = (int)spawnBounds.size.y + 1;

        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 tempPos = new Vector3((gridStartPoint.position.x + 0.5f) + x, (gridStartPoint.position.y + y + 0.5f), 0f);
                Instantiate(spawnPoint, tempPos, Quaternion.identity, transform);
            }
        }
    }
}
