﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float existTime;

    public bool isEnemyProjectile;
    public bool isIndicatorOn;

    private float timer = 0f;

    public Rigidbody rb;

    public Projectile(float speed, float acceleration)
    {
        this.speed = speed;
        this.acceleration = acceleration;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > existTime)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * acceleration);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isEnemyProjectile && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Enemy>().LoseHealth(10);
        } else if (isEnemyProjectile && other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);

            //To-Do Health loss
        } else if (isEnemyProjectile && isIndicatorOn && other.gameObject.CompareTag("Tile"))
        {
            other.gameObject.GetComponent<Tile>().WarnTile();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isEnemyProjectile && other.gameObject.CompareTag("Tile"))
        {
            other.gameObject.GetComponent<Tile>().UnwarnTile();
        }
    }


    public void SetSpeed(float newSpeed)
    {
        this.speed = newSpeed;
    }

    public void SetAcceleration(float newAccel)
    {
        this.acceleration = newAccel;
    }

    public void SetExistTime(float time)
    {
        this.existTime = time;
    }
}
