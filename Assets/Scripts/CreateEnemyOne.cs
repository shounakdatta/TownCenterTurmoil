using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateEnemyOne : MonoBehaviour {
    public Sprite[] enemySprite;
    public GameObject gameManager;
    public GameObject player;
    public GameManager managerScript;

	void Start ()
    {
        managerScript = gameManager.GetComponent<GameManager>();
	}
	
	void Update () { //This method handles individual enemy creation and movement for Level 1.

        if (gameObject.GetComponent<SpriteRenderer>().sprite == null)
            gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite();

        if (player.transform.position.x > (gameObject.transform.position.x - 1) && player.transform.position.x < (gameObject.transform.position.x + 1))
        {
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                Vector3 position = gameObject.transform.position;
                position.y += (float)(0.05);
                gameObject.transform.position = position;
            }
            else
            {
                Vector3 position = gameObject.transform.position;
                position.y -= (float)(0.05);
                gameObject.transform.position = position;
            }
        }
        else if (player.transform.position.y == gameObject.transform.position.y)
        {
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 position = gameObject.transform.position;
                position.x += (float)(0.05);
                gameObject.transform.position = position;
            }
            else
            {
                Vector3 position = gameObject.transform.position;
                position.x -= (float)(0.05);
                gameObject.transform.position = position;
            }
        }
        KillEnemy();
    }

    public Sprite GetSprite() //This method randomly retrieves enemy sprites with unique WASD codes.
    {
        int spriteNum = Random.Range(0, enemySprite.Length);
        return enemySprite[spriteNum];
    }

    void KillEnemy() //This method handles individual enemy elimination.
    {
        if (Input.GetKeyDown(KeyCode.W) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[0] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[4]))
            Destroy(gameObject);
        else if (Input.GetKeyDown(KeyCode.A) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[1] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[5]))
            Destroy(gameObject);
        else if (Input.GetKeyDown(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[2] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[6]))
            Destroy(gameObject);
        else if (Input.GetKeyDown(KeyCode.D) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[3] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[7]))
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision) //This method handles enemy collisions with the player and affects player life points.
    {
        if (collision.gameObject.tag == "Player" && player.GetComponent<PlayerMovement>().enabled == false)
        {
            Destroy(gameObject);
            managerScript.livesLeft -= 1;
        }
    }
}