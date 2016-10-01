using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Rigidbody2D player;
    
	void LateUpdate () {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
	}
}
