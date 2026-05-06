using UnityEngine;

public class Sistema_inimigos : MonoBehaviour
{
    [Header("Informações")]
    public int enemieLife;
    public float enemieSpeed;

    [Header("Movimentação")]
    public Transform playerPosition;
    public float enemieVelocity;

    [Header("Gatilho")]
    public bool activeEnemy;
    SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        activeEnemy = false;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Invocando a Função para Seguir o Jogador.
        SeguirJogador();
    }

    void SeguirJogador()
    {
        if(activeEnemy)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemieVelocity * Time.deltaTime);

            if(playerPosition.position.x > transform.position.x && spriteRenderer.flipX)
            {
                spriteRenderer.flipX = false;
            } else if(playerPosition.position.x < transform.position.x && !spriteRenderer.flipX)
            {
                spriteRenderer.flipX = true;
            }
        }
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
