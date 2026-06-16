using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ActiveEnemy : MonoBehaviour
{
    public List<GameObject> inimigos;
    public AgrupamentoInimigos agrupamento;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        inimigos = agrupamento.inimigos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in inimigos)
            {
                Sistema_inimigos sEnemies = obj.GetComponent<Sistema_inimigos>();
                sEnemies.activeEnemy = true;
            }
        }
    }
}
