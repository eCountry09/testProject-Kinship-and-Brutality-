using UnityEngine;

public class BarraVida : MonoBehaviour
{
    [Header("Informações")]
    float maxEnemy;
    public float actuallyEnemy;
    float vidaCalc;
    public Transform enemie;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxEnemy = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizarBarra(float vida)
    {
        vidaCalc = maxEnemy / actuallyEnemy;

        transform.localScale = new Vector2(vidaCalc * vida, transform.localScale.y);
        transform.position = new Vector2(enemie.position.x - vidaCalc, enemie.position.y + 0.45f);
    }
}
