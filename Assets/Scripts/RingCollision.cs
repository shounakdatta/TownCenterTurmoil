using UnityEngine;
using System.Collections;

public class RingCollision : MonoBehaviour {
    public GameObject gameManager;
    public GameObject player;
    public GameManager managerScript;

    void Start ()
    {
        managerScript = gameManager.GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D collision) //This method determines if the player has reached the end of the map, and if so, it displays the victory screen.
    {
        if (collision.gameObject.tag == "Player")
            managerScript.ringCollide = true;
    }
}
