using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class levelselect : MonoBehaviour {


    //Generates Random Number for puzzle
    //public Random rnd = new Random();

    public static int whichLevel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        //Random rnd = new Random();
        //int rndLevel = Random.Range(1, 2);
        Debug.Log(gameObject.name);

        if (gameObject.name == "Ending")
        {
            whichLevel = 1; //This id for testing purposes. Comment when done
            SceneManager.LoadScene("puzzle_1");
            

        }


        if (gameObject.name == "Prologue")
        {
            whichLevel = 2; //This id for testing purposes. Comment when done
            //SceneManager.LoadScene("Level1");

        }

        if (gameObject.name == "The Town")
        {
            whichLevel = 3; //This id for testing purposes. Comment when done
                            //SceneManager.LoadScene("Level2");

        }

        if (gameObject.name == "The Forest")
        {
            whichLevel = 4; //This id for testing purposes. Comment when done
            //SceneManager.LoadScene("Level3");

        }

        //SceneManager.LoadScene("puzzle_1");


    }
}
