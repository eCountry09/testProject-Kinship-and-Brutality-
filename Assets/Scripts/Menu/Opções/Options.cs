using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Button options;
    public GameObject painelConfigs;
    public bool optionsOpen;

    void Start()
    {
        optionsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void abrirPaineis(GameObject painel)
    {
        painel.SetActive(true);
    }

    public void fecharPaineis(GameObject painel)
    {
        painel.SetActive(false);
    }
}
