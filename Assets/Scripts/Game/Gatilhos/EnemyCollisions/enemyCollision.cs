using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    Collider2D meuCollisor;
    public Collider2D colisorParede;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        meuCollisor = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(meuCollisor, colisorParede, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
