using UnityEngine;

public class Sistema_inimigos : MonoBehaviour
{
    [Header("Informações")]
    public float enemieLife;
    float maxEnemy = 100f;
    public float enemieSpeed;

    [Header("Movimentação")]
    public Transform playerPosition;
    public float enemieVelocity;

    [Header("Game Manager")]
    public GameObject gm;

    [Header("Gatilho")]
    public bool activeEnemy;
    SpriteRenderer spriteRenderer;

    [Header("Vida")]
    public GameObject vida;
    public Transform rVida;
    float pctgmVida;

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

    void atualizarVida()
    {
        
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

    public void ReceberDano(int dano)
    {
        gameObject.transform.position = new Vector2(transform.position.x + 3, transform.position.y);
        enemieLife--;

        atualizarVida();

        if (enemieLife == 0)
        {
            GameObject.Destroy(gameObject);
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
