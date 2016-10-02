using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    private Animator animator;

	void Start () {
        animator = GetComponent<Animator>();
        animator.SetBool("isWalking", true);
    }
	
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            animator.SetBool("isWalking", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            animator.SetBool("isWalking", true);
        }
    }
}
