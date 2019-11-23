﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoss : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rigidBody;

    private SpriteRenderer spriteRenderer;

    public GameObject alienBullet;

    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 1.0f;
    public float baseFireWaitTime = 3.0f;

    public Sprite explodedShipImage;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(1, 0) * speed;

        spriteRenderer = GetComponent<SpriteRenderer>();

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

    }

    //Turn in opposite direction
    void Turn(int direction)
    {
        Vector2 newVelocity = rigidBody.velocity;
        newVelocity.x = speed * direction;
        rigidBody.velocity = newVelocity;
    }
    //Move down after hitting wall

    void MoveDown()
    {
        Vector2 position = transform.position;
        position.y -= 1;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "LeftWall")
        {
            Turn(1);
            MoveDown();
        }
        else
        {
            Turn(-1);
            MoveDown();
        }
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            //Hearth system TODO
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (Time.time > baseFireWaitTime)
        {

            baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);
            Instantiate(alienBullet, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
            collision.GetComponent<SpriteRenderer>().sprite = explodedShipImage;

            Destroy(gameObject);

            Object.Destroy(collision.gameObject, 0.5f);

        }
    }
}
