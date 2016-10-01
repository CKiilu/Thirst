using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameMaster : MonoBehaviour {

    public static int remainingPieces = 9;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (remainingPieces > 0)
        {
            MoveScript.timeBonus -= Time.deltaTime;
        }
        
        if (remainingPieces == 0)
        {
            SceneManager.LoadScene("levelcomplete");


        }
	
	}
}
