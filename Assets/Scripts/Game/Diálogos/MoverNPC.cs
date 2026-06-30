using System.Collections;
using UnityEngine;

public class MoverNPC : MonoBehaviour
{
    public Transform pontoA;
    public Transform pontoB;
    Vector3 destino;
    public float velocidade = 2f;
    public bool readyToAnim;
    Rigidbody2D rg;
    public NpcDialogueAnim npcDialogueAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rg = GetComponent <Rigidbody2D>();
        destino = pontoB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToAnim)
        {
            transform.position = Vector3.MoveTowards(transform.position, destino, velocidade * Time.deltaTime);

            if(transform.position == pontoB.position)
            {
                rg.linearVelocityX = 0f;
                StartCoroutine(iniciarDialogo());
            }
        }
    }

    IEnumerator iniciarDialogo()
    {
        yield return new WaitForSeconds(2);
        npcDialogueAnim.readyToSpeak = true;
        //npcDialogueAnim.readyToSpeak = true;
    }
}
