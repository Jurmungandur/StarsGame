using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripth : MonoBehaviour {

    public GameObject Player;

	void Start () {
		
	}
	
	void FixedUpdate () {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y+2, Player.transform.position.z-10);
	}
}
