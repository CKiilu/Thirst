using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyController : MonoBehaviour {
    private Rigidbody2D enemy;
    public Vector3 movementDirection;

    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        enemy.transform.Translate(movementDirection * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Edge"))
        {
            movementDirection *= -1;
        }
    }
}
