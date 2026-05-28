using System.Collections;
using UnityEngine;

public class fisicaCerveja : MonoBehaviour
{
    Rigidbody2D rb;
    public float force = 7f;
    public Transform throwerPos;
    public Transform playerPos;

    public GameObject brokenCerveja;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (playerPos.position.x > throwerPos.transform.position.x) //jogador t� na direita de mim (agora consertado)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(transform.position += transform.right * Time.deltaTime * force);
        }

        if (playerPos.position.x < throwerPos.transform.position.x) //jogador ta na esquerda de mim (funcionando!)
        {
            rb.linearVelocity = Vector2.zero;
            rb.AddForce(transform.position += -transform.right * Time.deltaTime * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            if (collision.collider != null && collision.collider.CompareTag("Player") || collision.collider.CompareTag("Floor"))
            {
                StartCoroutine(destroyCerveja());
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Collision2D error: " + e.Message);
        }
    }
    IEnumerator destroyCerveja()
    {
      //rb.bodyType = RigidbodyType2D.Static;
        force = 0;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}

