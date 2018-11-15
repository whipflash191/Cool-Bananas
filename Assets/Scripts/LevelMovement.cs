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

    //Off Screen Checks
    public float orthSize;
    public float aspRatio;
    public float gameWidth = 0;
    public float gameHeight = 0;
    public List<GameObject> tiles = new List<GameObject>();

    private void Start()
    {
        orthSize = Camera.main.orthographicSize;
        aspRatio = Camera.main.aspect;
        gameHeight = orthSize * 2;
        gameWidth = gameHeight * aspRatio;
    }

    private void Update()
    {
        foreach (GameObject item in tiles)
        {
            if (Vector2.Distance(item.transform.position, new Vector2(0, 0)) > (gameWidth / 2 + 0.5f))
            {
                print(item.transform.name + " " + Vector2.Distance(item.transform.position, new Vector2(0, 0)));
                item.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += Mathf.Lerp(0, maxSpeed, (Time.deltaTime * mvmntScale));
        }
        gameObject.transform.Translate((mvmntDirection * Time.deltaTime * currentSpeed));
    }
}