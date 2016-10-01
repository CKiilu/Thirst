using UnityEngine;

public class ItemCollection : MonoBehaviour {

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            ScoreManager.score += 1;
        }
    }
}
