using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public class MonologueManager : MonoBehaviour {

    public static bool playerMove = false;

    public GameObject monologuePanel;
    public Text receiveItemText;
    public string[] monologueString;
    public float textWriteSpeed;
    public bool triggered;

    private bool isWriting = false, endofMonologue = false, firstContact = true, hasReward;
    private int currentIndex;
    private StringBuilder currentLine;
    private Text monologueText;
    private Animator animator;
    private NPCController npcController;
    private PlayerController playerController;

	void Awake () {
        monologueText = monologuePanel.GetComponentInChildren<Text>();
        animator = GetComponent<Animator>();
        currentIndex = 0;
        hasReward = triggered;
        if (!triggered)
        {
            monologuePanel.SetActive(true);
            StartCoroutine(WriteText(monologueString[currentIndex]));
        }
    }

    void FixedUpdate () {
        if (Input.GetKeyUp(KeyCode.Space) && currentIndex + 1 < monologueString.Length && !isWriting)
        {
            if (!triggered)
            {
                StartCoroutine(WriteText(monologueString[++currentIndex]));
            }
        }
        if (endofMonologue && Input.GetKeyUp(KeyCode.Space))
        {
            monologuePanel.SetActive(false);
            playerMove = true;
            if (hasReward)
            {
                StartCoroutine(ReceiveItem());
            }
            if (npcController)
            {
                npcController.Move();
                if (animator)
                {
                    AnimateMovement(true);
                }
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
            other.gameObject.GetComponentInParent<PlayerController>().AnimateMovement(false);
            if (animator)
            {
                AnimateMovement(false);
            }
            PlayerController.overrideMovementLock = false;
            npcController = gameObject.GetComponent<NPCController>();
            if (npcController)
            {
                npcController.StopMovement();
            }
            StartCoroutine(WriteText(monologueString[currentIndex]));
        }
    }


    IEnumerator WriteText(string strComplete)
    {
        int i = 0;
        isWriting = true;
        currentLine = new StringBuilder();
        strComplete = Regex.Unescape(strComplete);
        while(i < strComplete.Length)
        {
            currentLine.Append(strComplete[i++]);
            monologueText.text = currentLine.ToString();
            yield return new WaitForSeconds(textWriteSpeed);
        }
        isWriting = false;

        if (currentIndex + 1 == monologueString.Length)
        {
            endofMonologue = true;
        }
    }

    IEnumerator ReceiveItem()
    {
        receiveItemText.text = "You have received an item!";
        yield return new WaitForSeconds(1.5f);
        receiveItemText.text = "";
        Destroy(this);
    }

    public void AnimateMovement(bool val)
    {
        animator.SetBool("isWalking", val);
    }
}
