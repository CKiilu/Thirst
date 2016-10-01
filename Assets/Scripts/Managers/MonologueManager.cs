using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public class MonologueManager : MonoBehaviour {

    public static bool playerMove = false;

    public GameObject monologuePanel;
    public string[] monologueString;
    public float textWriteSpeed;
    public bool triggered;

    private bool isWriting = false, endofMonologue = false, firstContact = true;
    private int currentIndex;
    private StringBuilder currentLine;
    private Text monologueText;
    private NPCController npcController;

	void Awake () {
        monologueText = monologuePanel.GetComponentInChildren<Text>();
        currentIndex = 0;
        if (!triggered)
        {
            monologuePanel.SetActive(true);
            StartCoroutine(WriteText(monologueString[currentIndex]));
        }
    }

    IEnumerator WriteText(string strComplete)
    {
        int i = 0;
        isWriting = true;
        currentLine = new StringBuilder();
        strComplete = Regex.Unescape(strComplete);
        while (i < strComplete.Length)
        {
            currentLine.Append(strComplete[i++]);
            monologueText.text = currentLine.ToString();
            if (i != strComplete.Length)
            {
                yield return new WaitForSeconds(textWriteSpeed);
            }
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
            if (!triggered)
            {
                StartCoroutine(WriteText(monologueString[++currentIndex]));
            }
        }
        if (endofMonologue && Input.GetKeyDown(KeyCode.Space))
        {
            monologuePanel.SetActive(false);
            playerMove = true;
            if (npcController)
            {
                npcController.Move();
            }            
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && firstContact)
        {
            monologuePanel.SetActive(true);
            firstContact = false;
            triggered = false;
            other.gameObject.GetComponentInParent<Rigidbody2D>().velocity = Vector3.zero;
            PlayerController.overrideMovementLock = false;
            npcController = gameObject.GetComponent<NPCController>();
            npcController.Stop();
            StartCoroutine(WriteText(monologueString[currentIndex]));
        }
    }
}
