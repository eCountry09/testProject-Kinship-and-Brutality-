using UnityEngine;

public class fisicaCerveja : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 20f;
    public GameObject myObject;
    public Transform playerPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerPos.position.x > myObject.transform.position.x) //jogador tá na direita de mim
        {
            rb.AddForce(transform.position += transform.up * Time.deltaTime * force);
        }

        if (playerPos.position.x < myObject.transform.position.x) //jogador ta na esquerda de mim (funcionando!)
        {
            rb.AddForce(transform.position += transform.up * Time.deltaTime * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão"))
        {
            Destroy(myObject);
        }
    }
}

