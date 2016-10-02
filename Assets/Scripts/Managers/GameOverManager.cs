using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    public PlayerController player;
    public Text restartText, gameoverText, receiveItemText;

    void Start () {
        restartText.text = "";
        gameoverText.text = "";
        if (receiveItemText)
        {
            receiveItemText.text = "";
        }
    }
	
	void Update () {
        if (player.Dead())
        {
            restartText.text = "Press 'R' to Restart.";
            gameoverText.text = "GAME OVER!";
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                ScoreManager.score = 0;
            }
        }
    }
}
