using UnityEngine;
using System.Collections;

public class PlayerAttacks : MonoBehaviour {
	public Sprite[] attacks;
	private Sprite stand;

	void Start () 
	{
		stand = gameObject.GetComponent<SpriteRenderer> ().sprite;
	}
	
	void Update () //This method handles player actions upon pressing the WASD keys. Each button displays a different action replicating dodging movements.
	{
		if (Input.GetKey(KeyCode.W))
			gameObject.GetComponent<SpriteRenderer>().sprite = attacks[2];	
		else if (Input.GetKey(KeyCode.A))
			gameObject.GetComponent<SpriteRenderer>().sprite = attacks[1];	
		else if (Input.GetKey(KeyCode.S))
			gameObject.GetComponent<SpriteRenderer>().sprite = attacks[0];	
		else if (Input.GetKey(KeyCode.D))
			gameObject.GetComponent<SpriteRenderer>().sprite = attacks[3];	
		else
			gameObject.GetComponent<SpriteRenderer>().sprite = stand;
	}
}
