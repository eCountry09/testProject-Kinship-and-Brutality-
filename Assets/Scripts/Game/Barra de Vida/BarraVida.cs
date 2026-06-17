using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    [Header("Configurações Visuais!")]
    public Image barraVida;

    [Header("Atributos!")]
    public float maxEnemy = 100f;
    float vidaAtual = 1;
    public float actuallyEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void atualizarBarra(float vida)
    {
        vidaAtual /= actuallyEnemy;
        vidaAtual *= vida;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, maxEnemy);

        barraVida.fillAmount = vidaAtual;
        vidaAtual = 1;
    }
}
