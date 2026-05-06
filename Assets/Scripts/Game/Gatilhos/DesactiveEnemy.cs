using UnityEngine;

public class DesactiveEnemy : MonoBehaviour
{
    public Sistema_inimigos sEnemies;
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
        if (collision.CompareTag("Player"))
        {
            if (sEnemies != null)
            {
                sEnemies.DesactiveEnemy();
            }
        }
    }
}
