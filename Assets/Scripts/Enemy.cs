﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    private float timer = 0f;
    public float timeToShoot;

    public float bulletSpeed;
    public float bulletAccel;
    public float bulletDespawn;

    
    // Start is called before the first frame update
    void Start()
    {
        //bm = board.GetComponent<BoardManager>();
        //boardSize = bm.tiles.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        if (timer >= timeToShoot)
        {
            Shoot();
            timer = 0f;
        }
    }

    new private void Shoot()
    {
        var newBullet = Instantiate(bullet, transform.position + (transform.forward * 2), transform.rotation);
        newBullet.SetSpeed(bulletSpeed);
        newBullet.SetAcceleration(bulletAccel);
        newBullet.SetExistTime(bulletDespawn);
        newBullet.isIndicatorOn = true;
    }
}
