using UnityEngine;
using System.Collections;

public class MoveLives : MonoBehaviour {
    public GameObject player;

    void Start () {
    }
	
	void Update () { //This method allows the player life indicator to move accross the map synchronously with the player.
        if (Input.GetKey(KeyCode.RightArrow) && player.GetComponent<PlayerMovement>().enabled == true && player.transform.position.x <= 89)
        {
            Vector3 position = this.transform.position;
            position.x += (float)(0.06);
            this.transform.position = position;
        }
    }
}
