using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NPCController : MonoBehaviour
{
    public Vector3 movementDirection;

    private bool canMove = true;
    private Rigidbody2D enemyRigidbody;
    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (canMove)
        {
            enemyRigidbody.transform.Translate(movementDirection * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            movementDirection *= -1;
            enemySpriteRenderer.flipX = !enemySpriteRenderer.flipX;
        }
    }

    public void Move()
    {
        canMove = true;
    }

    public void Stop()
    {
        canMove = false;
    }
}
