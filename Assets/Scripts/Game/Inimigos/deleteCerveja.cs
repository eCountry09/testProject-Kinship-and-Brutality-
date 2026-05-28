using System.Collections;
using UnityEngine;

/*public class deleteCerveja : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject brokenCerveja;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
*/