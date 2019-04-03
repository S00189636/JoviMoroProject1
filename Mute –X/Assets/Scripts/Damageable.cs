﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour {

	public int hits;
    
    virtual protected void Update()
    {
        if (hits <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Hit(float amount)
    {
        hits -= (int)amount;
    }
}
