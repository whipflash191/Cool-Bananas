﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleSpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("got here");
        if (collision.gameObject.tag == "Tile" || collision.gameObject.tag == "Gap")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
