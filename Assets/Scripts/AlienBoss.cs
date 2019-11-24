using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoss : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody2D rigidBody;

    public GameObject alienBullet;

    public GameObject bossHeart;
    private GameObject healthPanel;

    public float minFireRateTime = 1.0f;
    public float maxFireRateTime = 1.0f;
    public float baseFireWaitTime = 1.0f;
    public float bossHeartCount = 10;

    public Sprite explodedShipImage;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = new Vector2(1, 0) * speed;
        healthPanel = GameObject.FindGameObjectWithTag("BossHealth");

        baseFireWaitTime = baseFireWaitTime + Random.Range(minFireRateTime, maxFireRateTime);

        float delX = 0;

        for(int i = 0; i < bossHeartCount; i++)
        {
            Vector3 vector3HealthPanel = new Vector3(healthPanel.transform.position.x+delX, healthPanel.transform.position.y);
            Instantiate(bossHeart, vector3HealthPanel, Quaternion.identity);
            delX += 7f;

        }
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
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeSinceLevelLoad > baseFireWaitTime)
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
