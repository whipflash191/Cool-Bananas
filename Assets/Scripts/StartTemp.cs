using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class StartTemp : MonoBehaviour {
    public AudioSource btnSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        btnSound.Play();
        SceneManager.LoadScene(1);
    }
}
