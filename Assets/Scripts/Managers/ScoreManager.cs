using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    public static int score = 0;
    public int itemCount;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
    }
    
	void Update () {
        scoreText.text = score + " / " + itemCount + " collected";
	}
 }
