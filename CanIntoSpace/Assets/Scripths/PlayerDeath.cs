using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {

    void OnCollisionEnter(Collision col) {
        Debug.Log("Hit");
    }

}
