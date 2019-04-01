﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    const int MAX_XP = 100;
    const int MaxHealth = 100;
    const int MAX_SPEED = 7;
    public int Ammo = 20;
    public int Level = 1 ;
    public float Speed = 2;
    public float Xp = 0;
    public bool Detected = false;
    public int Health;

    private void Start()
    {
        ResetPlayerData();
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Xp > MAX_XP)
        {
            Xp = 0;
            Level++;
            Speed *= Level;
            if (Speed > MAX_SPEED)
            {
                Speed = MAX_SPEED;
            }
        }
    }
    public void ResetPlayerData()
    {
        Health = MaxHealth;
        Detected = false;
    }

    public void DamegPlayer(int amount)
    {
        if (Health > 0)
        {
            Health -= amount;
            Debug.Log("Dameg: "+amount);
        }
    }
}
