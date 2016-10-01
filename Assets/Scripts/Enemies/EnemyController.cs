using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public Vector3 movementDirection;
    public Sprite[] enemySprites;

    private bool flipValue = true;
    private Rigidbody2D enemyRigidbody;
    private SpriteRenderer enemySpriteRenderer;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    void Update()
    {
        enemyRigidbody.transform.Translate(movementDirection * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            movementDirection *= -1;
            enemySpriteRenderer.flipX = flipValue;
            flipValue = !flipValue;
        }
    }
}
