using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class EndTemp: MonoBehaviour
{
    public AudioSource btnSound;
    TextMeshProUGUI scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        btnSound.Play();
        SceneManager.LoadScene(1);
    }
}