using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    public int itemCount;
    public string sceneName;

    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    
	void Update () {
        if (scoreText)
        {
            scoreText.text = score + " / " + itemCount + " collected";
        }
        if(score == itemCount)
        {
            SceneManager.LoadScene(sceneName);
        }
	}
 }
