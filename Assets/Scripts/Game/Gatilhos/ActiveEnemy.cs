using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class ActiveEnemy : MonoBehaviour
{
    public List<GameObject> inimigos;
    public List<GameObject> outInimigos;
    public GameObject Enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void reiniciarObjEnemies()
    {
        outInimigos = new List<GameObject>();
        
        foreach (GameObject objeto in inimigos)
        {
            if(objeto == null)
            {
                inimigos.Remove(objeto);
                outInimigos = new List<GameObject>();

                foreach (GameObject newObject in inimigos)
                {
                    outInimigos.Add(newObject);
                }
            }

            inimigos = new List<GameObject>();
            inimigos = outInimigos;
        }
    }
}
