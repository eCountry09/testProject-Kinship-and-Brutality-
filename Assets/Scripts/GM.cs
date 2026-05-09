using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GM : MonoBehaviour
{
    [Header("Vida do Player")]
    public TextMeshProUGUI textoVida;
    float playerLife;

    [Header("Painéis")]
    public GameObject painelGameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLife = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void abrirCenas(string cena)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(cena);
    }

    public void abrirPaineisGame(GameObject painel)
    {
        Time.timeScale = 0;
        painel.SetActive(true);
    }

    public void perderVida(float dano)
    {
        playerLife -= dano;
        atualizarVida();

        if(playerLife <= 0)
        {
            abrirPaineisGame(painelGameOver);
        }
    }

    public void atualizarVida()
    {
        textoVida.text = "Vida: " + playerLife;
    }
}
