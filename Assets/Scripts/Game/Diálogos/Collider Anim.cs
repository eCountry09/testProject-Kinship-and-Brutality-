using UnityEngine;

public class ColliderAnim : MonoBehaviour
{
    public NpcDialogueAnim npcDialogueAnim;
    public MoverNPC moverNPC;
    public bool actDialogue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            moverNPC.readyToAnim = true;
            npcDialogueAnim.player.velocidade = 0f;
            actDialogue = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            actDialogue = true;
        }
    }
}
