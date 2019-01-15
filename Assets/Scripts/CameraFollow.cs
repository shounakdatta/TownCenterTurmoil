using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	public float smoothTimeX;
	public float smoothTimeY;
	public GameObject player;
	public bool camFollow = false;
    private Vector2 velocity;

    void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
    }

    void FixedUpdate () 
	{
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		transform.position = new Vector3 (posX, transform.position.y, transform.position.z);
	}
}
