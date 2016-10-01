using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Rigidbody2D player;
    public float limit;
    
	void LateUpdate () {
        Vector3 movement = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (limit == 0 || movement.x < limit)
        {
            transform.position = movement;
        }
	}
}
