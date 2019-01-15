using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    private Sprite player;

    void Start()
    {
        player = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    void Update ()
    {
		if (Input.GetKey(KeyCode.RightArrow) && gameObject.transform.position.x < 89)
		{
			Vector3 position = this.transform.position;
			position.x += (float)(0.06);
			this.transform.position = position;
            gameObject.GetComponent<Animator>().enabled = true;
		}
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			gameObject.GetComponent<Animator>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().sprite = player;
		}
    }
}
