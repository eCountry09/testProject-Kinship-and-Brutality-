using UnityEngine;

public class Sistema_inimigos : MonoBehaviour
{
    [Header("Informações")]
    public float enemieLife;
    BarraVida bVida;

    [Header("Movimentação e Ataque")]
    public Transform playerPosition;
    public float enemieVelocity;
    public float enemieAttack;
    public Player player;

    [Header("Game Manager")]
    public GM gm;

    [Header("Gatilho")]
    public AtivacaoInimigos ativacao;
    SpriteRenderer spriteRenderer;
    public bool activeEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Parâmetros para a Barra.
        bVida = GetComponentInChildren<BarraVida>();

        // Inicializaão da Barra.
        bVida.actuallyEnemy = enemieLife;
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

    public void ReceberDano()
    {
        gameObject.transform.position = new Vector2(transform.position.x + 3, transform.position.y);
        enemieLife--;

        bVida.atualizarBarra(enemieLife);

        if (enemieLife == 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerPosition.position = new Vector2(playerPosition.position.x - 3, playerPosition.position.y);
            gm.perderVida(enemieAttack);
        }
    }
}
