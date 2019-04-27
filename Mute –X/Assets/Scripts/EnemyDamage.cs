﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : Damageable {

    public bool DropPickup;
    public PickupsType PickupType;
    int Damage;
    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    protected override void Update()
    {
        if (hits <= 0)
        {
            if (DropPickup)
            {
                Damage = GetComponent<EnemyAttack>().Damage;
				if (Damage <= 0) Damage = 5;
                int amount = Damage / 2;
                if (amount < 10) amount = 10;
                gameController.DropPickup(transform.position, amount, PickupType);
            }
            gameController.EnemyKilled();
            Destroy(GetComponent<FollowPath>().path.gameObject);
            Destroy(gameObject);
        }
    }
}
