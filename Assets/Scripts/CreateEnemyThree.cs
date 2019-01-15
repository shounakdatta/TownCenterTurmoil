using UnityEngine;
using System.Collections;

public class CreateEnemyThree : MonoBehaviour {
    public Sprite[] enemySprite;
    public GameObject gameManager;
    public GameObject player;
    public GameManager managerScript;
    private bool oneCorrect = false, twoCorrect = false;

    void Start()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    void Update() //This method handles individual enemy creation and movement for Level 3.
    {
        if (gameObject.GetComponent<SpriteRenderer>().sprite == null)
            gameObject.GetComponent<SpriteRenderer>().sprite = GetSprite();

        if (player.transform.position.x > (gameObject.transform.position.x - 1) && player.transform.position.x < (gameObject.transform.position.x + 1))
        {
            if (player.transform.position.y > gameObject.transform.position.y)
            {
                Vector3 position = gameObject.transform.position;
                position.y += (float)(0.025);
                gameObject.transform.position = position;
            }
            else
            {
                Vector3 position = gameObject.transform.position;
                position.y -= (float)(0.025);
                gameObject.transform.position = position;
            }
        }
        else if (player.transform.position.y == gameObject.transform.position.y)
        {
            if (player.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 position = gameObject.transform.position;
                position.x += (float)(0.025);
                gameObject.transform.position = position;
            }
            else
            {
                Vector3 position = gameObject.transform.position;
                position.x -= (float)(0.025);
                gameObject.transform.position = position;
            }
        }
        KillEnemy();
    }

    public Sprite GetSprite() //This method randomly retrieves enemy sprites with unique WASD codes.
    {
        int spriteNum = Random.Range(0, enemySprite.Length - 1);
        return enemySprite[spriteNum];
    }

    void KillEnemy() //This method handles individual enemy elimination.
    {
        if (Input.GetKeyUp(KeyCode.W) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[0] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[4]) || oneCorrect == true)
        {
            oneCorrect = true;
            if (Input.GetKeyUp(KeyCode.A) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[0] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[4]) || twoCorrect == true)
            {
                twoCorrect = true;
                if (Input.GetKeyUp(KeyCode.W) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[0]))
                    Destroy(gameObject);
                else if (Input.GetKeyUp(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[4]))
                    Destroy(gameObject);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[1] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[5]) || oneCorrect == true)
        {
            oneCorrect = true;
            if (Input.GetKeyUp(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[1] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[5]) || twoCorrect == true)
            {
                twoCorrect = true;
                if (Input.GetKeyUp(KeyCode.W) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[1]))
                    Destroy(gameObject);
                else if (Input.GetKeyUp(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[5]))
                    Destroy(gameObject);
            }
        }
        if (Input.GetKeyUp(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[2] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[6]) || oneCorrect == true)
        {
            oneCorrect = true;
            if (Input.GetKeyUp(KeyCode.A) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[2] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[6]) || twoCorrect == true)
            {
                twoCorrect = true;
                if (Input.GetKeyUp(KeyCode.W) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[2]))
                    Destroy(gameObject);
                else if (Input.GetKeyUp(KeyCode.D) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[6]))
                    Destroy(gameObject);
            }
        }
        if (Input.GetKeyUp(KeyCode.D) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[3] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[7]) || oneCorrect == true)
        {
            oneCorrect = true;
            if (Input.GetKeyUp(KeyCode.A) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[3] || gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[7]) || twoCorrect == true)
            {
                twoCorrect = true;
                if (Input.GetKeyUp(KeyCode.S) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[3]))
                    Destroy(gameObject);
                else if (Input.GetKeyUp(KeyCode.D) && (gameObject.GetComponent<SpriteRenderer>().sprite == enemySprite[7]))
                    Destroy(gameObject);
            }
        }
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