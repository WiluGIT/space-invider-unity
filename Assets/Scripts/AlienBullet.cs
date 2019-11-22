using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour {



    private Rigidbody2D rigidBody;
    public float speed = 30;

    public Sprite explodedShipImage;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();

        rigidBody.velocity = Vector2.down * speed;
    }
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Wall")
        {
            Destroy(gameObject);
        }
        if(col.tag=="Player")
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.shipExplosion);
            col.GetComponent<SpriteRenderer>().sprite = explodedShipImage;
            Destroy(gameObject);

#pragma warning disable CS0618 // Type or member is obsolete
            DestroyObject(col.gameObject, 0.5f);
#pragma warning restore CS0618 // Type or member is obsolete
        }
        if (col.tag == "Shield")
        {
            Destroy(gameObject);
#pragma warning disable CS0618 // Type or member is obsolete
            DestroyObject(col.gameObject);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }
    
}
