﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameController: MonoBehaviour {


    public bool paused = false;
    public bool firstLevl = false;
    public GameObject pauseMenu;
    Vector3 startingPoint;
    PlayerData data;
    GameObject player;
    


    private void Start()
    {
        pauseMenu = Instantiate(pauseMenu);
        DontDestroyOnLoad(gameObject);
        firstLevl = true;
    }

    private void Update()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        if (index > 0 )
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!paused)
                {
                    Pause();
                }
                else Resume();
            }
            if (firstLevl)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                data = player.GetComponent<PlayerData>();
                startingPoint = GameObject.FindGameObjectWithTag("StartingPoint").GetComponent<Transform>().position;
                player.transform.position = startingPoint;
                DontDestroyOnLoad(player);
                firstLevl = false;
            }
            
        }

        switch (index)
        {
            case 1:
                // write level 1 code here
                break;
            case 2:
                // write level 2 code here 
                break;
            case 3:
                // write level 3 code here 
                break;
            case 4:
                // write level 4 code here
                break;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        paused = !paused;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        paused = !paused;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

 
    public bool PlayerAlive()
    {
        
        if (data.Health <= 0)
        {
            return false;
        }
        else return true;
    }

    public void GoToLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        Resume();
        Destroy(gameObject);
    }

    public void RestartLevel()
    { 
        player.transform.position = startingPoint;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

    public void PlayerDetected()
    {
        data.Detected = true;
    }
    public void PlayerUnDetected()
    {
        data.Detected = false;
    }

    public bool IsPlayerDetected()
    {
        return data.Detected;
    }

    public Transform PlayerLocation()
    {
        return player.transform;
    }

    public void DamagePlayer(int amount)
    {
        data.DamegPlayer(amount);
    }
}
