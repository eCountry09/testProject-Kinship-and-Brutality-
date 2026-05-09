using UnityEngine;

public class AtivacaoInimigos : MonoBehaviour
{
    public bool activeEnemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveEnemy()
    {
        activeEnemy = true;
    }

    public void DesactiveEnemy()
    {
        activeEnemy = false;
    }
}
