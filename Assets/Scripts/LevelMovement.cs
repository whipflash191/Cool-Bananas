/*
* Copyright (c) Dylan Faith (Whipflash191)
* https://twitter.com/Whipflash191
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMovement : MonoBehaviour {
    public Vector3 mvmntDirection;
    [Range(0, 100)]
    public float mvmntScale;
    [Range(0, 100)]
    public float maxSpeed;
    public float currentSpeed;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if(currentSpeed < maxSpeed)
        {
            currentSpeed += Mathf.Lerp(0, maxSpeed, (Time.deltaTime * mvmntScale));
        }
        gameObject.transform.Translate((mvmntDirection * Time.deltaTime * currentSpeed));
    }
}
