using Unity.VisualScripting;
using UnityEngine;

public class AtivacaoInimigos : MonoBehaviour
{
    public GameObject[] inimigos;
    public GameObject gPainel;
    public GameObject rPainel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemy();
        desactiveEnemy();
    }

    public void activeEnemy()
    {
        BoxCollider2D colliderG = gPainel.GetComponent<BoxCollider2D>();

        if(colliderG.gameObject.CompareTag("Player"))
        {
            for(int i = 1; i <= inimigos.Length; i++)
            {
                Sistema_inimigos sEnemies = inimigos[i].GetComponent<Sistema_inimigos>();
                sEnemies.activeEnemy = true;
            }
        }
    }

    public void desactiveEnemy()
    {
        BoxCollider2D colliderR = rPainel.GetComponent<BoxCollider2D>();

        if (colliderR.gameObject.CompareTag("Player"))
        {
            for (int i = 1; i <= inimigos.Length; i++)
            {
                Sistema_inimigos sEnemies = inimigos[i].GetComponent<Sistema_inimigos>();
                sEnemies.activeEnemy = false;
            }
        }
    }
}
