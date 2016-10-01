using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

public class MonologueManager : MonoBehaviour {

    public static bool playerMove = false;

    public GameObject monologuePanel;
    public string[] monologueString;
    public float textWriteSpeed;

    private bool isWriting = false, endofMonologue = false;
    private int currentIndex;
    private StringBuilder currentLine;
    private Text monologueText;

	void Awake () {
        monologueText = monologuePanel.GetComponentInChildren<Text>();
        currentIndex = 0;
        StartCoroutine(WriteText(monologueString[currentIndex]));
    }

    IEnumerator WriteText(string strComplete)
    {
        int i = 0;
        isWriting = true;
        currentLine = new StringBuilder();
        while (i < strComplete.Length)
        {
            currentLine.Append(strComplete[i++]);
            monologueText.text = currentLine.ToString();
            yield return new WaitForSeconds(textWriteSpeed);
        }
        isWriting = false;
        if(currentIndex + 1 == monologueString.Length)
        {
            endofMonologue = true;
        }
    }

    void FixedUpdate () {
        if (Input.GetKeyDown(KeyCode.Space) && currentIndex + 1 < monologueString.Length && !isWriting)
        {
            StartCoroutine(WriteText(monologueString[++currentIndex]));
        }
        if (endofMonologue)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Destroy(monologuePanel);
                playerMove = true;
            }
        }
    }
}
