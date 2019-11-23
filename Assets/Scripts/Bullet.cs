using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float speed = 30;

    private Rigidbody2D rigidBody;

    public Sprite explodedAlienImage;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        
        rigidBody.velocity = Vector2.up * speed;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
       if(col.tag=="Wall")
        {
            Destroy(gameObject);
        }
       if(col.tag=="Alien")
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUiScore(10);
            
           
            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            Destroy(gameObject);


            Object.Destroy(col.gameObject, 0.5f);

        }
        if (col.tag == "AlienBoss")
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            IncreaseTextUiScore(100);


            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            Destroy(gameObject);


            Object.Destroy(col.gameObject, 0.5f);

        }
        if (col.tag=="Shield")
        {
            Destroy(gameObject);

            Object.Destroy(col.gameObject);

        }
    }

    void OnBecomeInvisible()
    {
        Destroy(gameObject);
    }

    void IncreaseTextUiScore(int points)
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        int score = int.Parse(textUIComp.text);
        score += points;
        textUIComp.text = score.ToString();

    }




}
