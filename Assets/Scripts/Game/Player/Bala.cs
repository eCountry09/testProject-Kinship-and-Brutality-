using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float tempoDeVida;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        transform.Translate(transform.up * speed * Time.fixedDeltaTime, Space.World);
    }
}
