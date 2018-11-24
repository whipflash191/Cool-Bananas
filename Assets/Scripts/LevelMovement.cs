/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour
{
    //Level Movement
    public Vector3 mvmntDirection;
    [Range(0, 100)]
    public float mvmntScale;
    [Range(0, 100)]
    public float maxSpeed;
    public float currentSpeed;

    public float xIncrement = -4.096f;
    public float yIncrement = 2.256f;

    //Off Screen Checks
    public float orthSize;
    public float aspRatio;
    public float gameWidth = 0;
    public float gameHeight = 0;
    public float distanceFromCentre = 0.5f;
    public List<GameObject> activeTiles = new List<GameObject>();
    public List<GameObject> inactiveTiles = new List<GameObject>();

    private void Start()
    {
        orthSize = Camera.main.orthographicSize;
        aspRatio = Camera.main.aspect;
        gameHeight = orthSize * 2;
        gameWidth = gameHeight * aspRatio;
    }

    private void Update()
    {
        List<GameObject> tempTiles = new List<GameObject>();
        foreach (GameObject item in activeTiles)
        {
            tempTiles.Add(item);
        }

        foreach (GameObject item in activeTiles)
        {
            if (Vector2.Distance(item.transform.position, new Vector2(0, 0)) > (gameWidth / 2 + distanceFromCentre))
            {
                if(item == activeTiles[0])
                {
                    tempTiles.Remove(item);
                    int tileToAdd = (int)Random.Range(0, inactiveTiles.Count - 1);
                    tempTiles.Add(inactiveTiles[tileToAdd]);
                    inactiveTiles.RemoveAt(tileToAdd);
                    inactiveTiles.Add(item);
                    tempTiles[tempTiles.Count - 1].transform.position = new Vector3((tempTiles[(tempTiles.Count - 2)].transform.position.x + 40.96f), (tempTiles[(tempTiles.Count - 2)].transform.position.y + -20.48f), tempTiles[(tempTiles.Count - 2)].transform.position.z);
                }
                item.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
               item.GetComponent<SpriteRenderer>().enabled = true;
            }
        }

        activeTiles = tempTiles;
    }

    private void FixedUpdate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += Mathf.Lerp(0, maxSpeed, (Time.deltaTime * mvmntScale));
        }
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + xIncrement, gameObject.transform.position.y + yIncrement, gameObject.transform.position.z);
        gameObject.transform.Translate((mvmntDirection * Time.deltaTime * currentSpeed));
    }
}