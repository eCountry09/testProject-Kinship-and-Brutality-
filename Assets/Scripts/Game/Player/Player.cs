using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;


public class Player : MonoBehaviour
{
    /* Teclas:
    Z => Atacar
    X => Pular
    SHIFT => Correr*/


    [Header("Movimento")]
    public float velocidade = 5f;
    Rigidbody2D rig;
    Vector2 mover;
    PlayerControle controle;

    [Header("Pulo")]
    public float forcaPulo = 6f;

    bool ehChao;
    public UnityEngine.Transform ehPe;
    public LayerMask chao;
    public float raioPe = 0.3f;
    int pulos;

    Animator animator;
    //SpriteRenderer spriteRenderer;


    private void Awake()
    {
        controle = new PlayerControle();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //spriteRenderer = GetComponent<SpriteRenderer>();

        pulos = 2;
    }

    private void OnEnable()
    {
        controle.Enable();
    }
    private void OnDisable()
    {
        controle.Disable();
    }
    // Update is called once per frame
    void Update() //executa a cada frame
    {
        // Movimentação.
        mover = controle.Player.Move.ReadValue<Vector2>();

        if(mover.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(Mathf.Abs(mover.x), 0, 0);
        }

        //Pulo.
        if (controle.Player.Jump.WasPressedThisFrame())
        {
            rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
        }

        // Verificação para saber se o Player está no chão.
        ehChao = Physics2D.OverlapCircle(ehPe.position, raioPe, chao);

        //Rotação do Sprite.
        if (mover.x != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(mover.x), 1, 1);
        }
    }

    private void FixedUpdate() //executa e um valor fixo, 50 X/ segundo
    {
        rig.linearVelocityX = mover.x * velocidade;
    }

    void Atacar()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }
}
