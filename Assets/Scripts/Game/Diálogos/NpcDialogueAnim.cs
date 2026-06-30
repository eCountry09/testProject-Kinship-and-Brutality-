using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;

public class NpcDialogueAnim : MonoBehaviour
{
    public string[] dialogueNpc;
    public int dialogueIndex;

    public GameObject dialogueAnim;
    public TextMeshProUGUI dialogueText;

    public TextMeshProUGUI nameNpc;
    public Image imageNpc;
    public Sprite spriteNpc;

    public bool readyToSpeak;
    public bool startDialogue;

    public float speedPlayer;

    [SerializeField]
    public Player player;
    Animator animator;
    public Rigidbody2D rg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
        dialogueAnim.SetActive(false);
        speedPlayer = player.velocidade;
    }

    // Update is called once per frame
    void Update()
    {
        if (readyToSpeak)
        {
            if (!startDialogue)
            {
                player.velocidade = 0f;
                StartDialogue();
            }
            else if (dialogueText.text == dialogueNpc[dialogueIndex] && Input.GetKeyDown(KeyCode.E))
            {
                NextDialogue();
            }
        }
    }

    void NextDialogue()
    {
        dialogueIndex++;

        if (dialogueIndex < dialogueNpc.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialogueAnim.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            player.velocidade = speedPlayer;
            readyToSpeak = false;
        }
    }

    void StartDialogue()
    {
        nameNpc.text = "Marcos";
        imageNpc.sprite = spriteNpc;
        dialogueIndex = 0;
        startDialogue = true;
        dialogueAnim.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letter in dialogueNpc[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
    }

    void systemFX()
    {
        if(rg.linearVelocityX != 0)
        {
            animator.SetTrigger("andar");
        } else
        {
            animator.SetTrigger("parar");
        }
    }
}
