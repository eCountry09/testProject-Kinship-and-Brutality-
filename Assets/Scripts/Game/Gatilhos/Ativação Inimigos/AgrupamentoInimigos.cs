using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class AgrupamentoInimigos : MonoBehaviour
{
    public List<GameObject> inimigos;
    public List<GameObject> outInimigos;
    public ActiveEnemy activeEnemy;
    public DesactiveEnemy desactiveEnemy;

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
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).CompareTag("Inimigo"))
            {
                inimigos.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    public void reiniciarObjEnemies(GameObject obj)
    {
        outInimigos = new List<GameObject>();

        foreach (GameObject objeto in inimigos)
        {
            if (objeto == obj)
            {
                inimigos.Remove(objeto);

                foreach (GameObject newObject in inimigos)
                {
                    outInimigos.Add(newObject);
                }
            }
        }

        inimigos = outInimigos;

        activeEnemy.inimigos = new List<GameObject>();
        activeEnemy.inimigos = inimigos;

        desactiveEnemy.inimigos = new List<GameObject>();
        desactiveEnemy.inimigos = inimigos;
    }
}
