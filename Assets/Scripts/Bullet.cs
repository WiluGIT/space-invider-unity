using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (col.tag == "Alien")
        {

            col.GetComponent<SpriteRenderer>().sprite = explodedAlienImage;
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            Destroy(gameObject);
            Object.Destroy(col.gameObject, 0.3f);

        }
        if (col.tag == "AlienBoss")
        {

            SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDies);
            Destroy(gameObject);
            if (GameObject.FindGameObjectsWithTag("Heart").Length > 0)
            {
                Object.Destroy(GameObject.FindGameObjectsWithTag("Heart")[GameObject.FindGameObjectsWithTag("Heart").Length - 1]);
                IncreaseTextUiScore(10);

            }
            else if (GameObject.FindGameObjectsWithTag("Heart").Length == 0)
            {
                Destroy(GameObject.FindGameObjectsWithTag("AlienBoss")[0]);
            }
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
        ScoreScript.instance.score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);

        ScoreScript.instance.score += points;
        
        textUIComp.text = ScoreScript.instance.score.ToString();

    }




}
