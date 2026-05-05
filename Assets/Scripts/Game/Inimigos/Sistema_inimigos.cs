using UnityEngine;

public class Sistema_inimigos : MonoBehaviour
{
    [Header("Informações")]
    public int enemieLife;
    public float enemieSpeed;

    [Header("Movimentação")]
    public Transform playerPosition;
    public float enemieVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SeguirJogador();
    }

    void SeguirJogador()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemieVelocity * Time.deltaTime);
    }
}
