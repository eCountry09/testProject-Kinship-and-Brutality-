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
        mover = controle.Player.Move.ReadValue<Vector2>();

        if(mover.x > 0.1f)
        {
            transform.rotation = Quaternion.Euler(Mathf.Abs(mover.x), 0, 0);
        }

        if (controle.Player.Jump.WasPressedThisFrame())
        {
            if(pulos >= 1)
            {
                rig.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
                pulos--;
            } else if(ehChao)
            {
                pulos = 2;
            }

            /*if (pulos == 0 && ehChao)
            {
                pulos = 2;
            }*/
        }

        ehChao = Physics2D.OverlapCircle(ehPe.position, raioPe, chao);
        animar();
    }

    private void FixedUpdate() //executa e um valor fixo, 50 X/ segundo
    {
        rig.linearVelocityX = mover.x * velocidade;
    }

    void animar()
    {
        animator.SetFloat("andar", Mathf.Abs(rig.linearVelocityX));

        if(ehChao)
        {
            animator.SetBool("pular", false);
            animator.SetBool("cair", false);

        } else if(rig.linearVelocity.y < -0.1f)
        {
            animator.SetBool("pular", true);
            animator.SetBool("cair", true);
        }
    }

    void Atacar()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            
        }
    }
}
