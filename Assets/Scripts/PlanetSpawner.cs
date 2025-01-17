﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public Sprite[] planetSprites;
    public GameObject planet;
    private List<GameObject> planets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // create a near planet and a far planet to start
        GeneratePlanet(true);
        GeneratePlanet(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject p in planets) {

            // if a planet reaches 1/2 way down the screen and there are less than 3 planets make a new far away one
            if (p.transform.position.y <= 0 && planets.Count < 3) {
          
                    GeneratePlanet(false);
   
                break;
            }
            // if the planet falls a far enough distance, destroy it and generate a replacement
            if (p.transform.position.y <= -90)
            {
                planets.Remove(p);
                if (p.transform.localScale.x == 20)
                {
                    GeneratePlanet(true);
                }
                else
                {
                    GeneratePlanet(false);
                }

                Destroy(p);
                break;
            }
        }
    }

    void GeneratePlanet(bool near) {
        // generate a random position on the x axis that is on screen and a fixed y that is above the screen
        Vector3 position = new Vector3(Random.Range(-230.0f, 230.0f), 120f, 0);

        // instantiate a new planet at that position
        GameObject newPlanet = Instantiate(planet, position, Quaternion.identity);

        /// randomise the planet's sprite
        int i = Random.Range(0, planetSprites.Length);
        SpriteRenderer spriteRenderer = newPlanet.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = planetSprites[i];
        spriteRenderer.sortingOrder = 3;
        newPlanet.transform.localScale = new Vector3(20f, 18f, 1);
        // Set the scale and speed dependant on if the planet is near or far
        Rigidbody2D rb2d = newPlanet.GetComponent<Rigidbody2D>();
        float fallSpeed = -10f;

        // far planets fall slower, are smaller and render behind near planets
        if (!near)
        {
            fallSpeed = -5f;
            float randomSize = Random.Range(-4f, 15f);
            newPlanet.transform.localScale = new Vector3(randomSize, randomSize, 1);
            spriteRenderer.sortingOrder = 2;
        }
        
        rb2d.velocity = new Vector2(0, fallSpeed);
        planets.Add(newPlanet);
    }
}
