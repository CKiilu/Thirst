using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class levelselect : MonoBehaviour {


    //Generates Random Number for puzzle
    //public Random rnd = new Random();

    public static int whichLevel;

    private AudioSource acceptSound;


    // Use this for initialization
    void Start()
    {
        acceptSound = GetComponentInParent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        acceptSound.Play();
        StartCoroutine(Wait(gameObject));    
        
 
        Debug.Log(gameObject.name);
        
    }

    IEnumerator Wait(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);

        switch (gameObject.name)
        {
            case "Ending":
                whichLevel = 1; //This id for testing purposes. Comment when done

                SceneManager.LoadScene("puzzle_1");
                break;


            case "Prologue":
                whichLevel = 2; //This id for testing purposes. Comment when done

                SceneManager.LoadScene("Level1");
                break;

            case "The Town":
                whichLevel = 3; //This id for testing purposes. Comment when done

                //SceneManager.LoadScene("Level2");
                break;


            case "The Forest":
                whichLevel = 4; //This id for testing purposes. Comment when done

                //SceneManager.LoadScene("Level3");

                break;
        }
    }
}
