using UnityEngine;

public class SistemaArma : MonoBehaviour
{
    Vector2 mousePosi;
    Vector2 dirArma;

    float angle;

    [SerializeField] SpriteRenderer srGun;

    [SerializeField] float tempoEntreTiros;
    bool podeAtirar = true;

    [SerializeField] Transform pontoDeFogo;
    [SerializeField] GameObject tiro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosi = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.P) && podeAtirar)
        {
            podeAtirar = false;
            Instantiate(tiro, pontoDeFogo.position, pontoDeFogo.rotation);
            Invoke("CDTiro", tempoEntreTiros);
        }
    }

    void FixedUpdate()
    {
        dirArma = mousePosi - new Vector2(transform.position.x, transform.position.y);
        angle = Mathf.Atan2(dirArma.y, dirArma.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
    void CDTiro()
    {
        podeAtirar = true;
    }
}
