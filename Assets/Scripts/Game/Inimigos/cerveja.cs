using UnityEngine;

public class cerveja : MonoBehaviour
{
    public GameObject myObject;
    public GameObject player;

    public Transform playerPos;
    public float walkSpeed;

    public float cooldown;
    public GameObject garrafa;
    public Rigidbody2D garrafaRB;
    float garrafaThrowForce = 20f;

    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        garrafaRB = garrafa.GetComponent<Rigidbody2D>();
        cooldown = 4;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(myObject.transform.position, player.transform.position); //medir distância

        if (distance < 15)//seguir o player quando a distancia diminuir
        {
            onChase();
        }
            //flipar imagem
           if (playerPos.position.x > myObject.transform.position.x && spriteRenderer.flipX)
           {
                spriteRenderer.flipX = false;
           }
           if (playerPos.position.x < myObject.transform.position.x && !spriteRenderer.flipX)
           {
                spriteRenderer.flipX = true;
           }

    }
    void onChase()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, walkSpeed * Time.deltaTime);

        cooldown = cooldown - Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = 4;
            Instantiate(garrafa, transform.position, transform.rotation);
        }
    }

}
