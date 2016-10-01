using UnityEngine;
using System.Collections;

public class scorecontrol : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Renderer>().sortingOrder = 15;
	
	}
	
	// Update is called once per frame
	void Update () {

        if (MoveScript.timeBonus < 0)
        {
            MoveScript.timeBonus = 0;
        }

        GetComponent<TextMesh>().text = "Bonus :" + Mathf.RoundToInt(MoveScript.totalScore + MoveScript.timeBonus).ToString();
	
	}
}
