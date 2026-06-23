using System.Collections;
using TMPro;
using UnityEngine;
public class typeTextAnimation : MonoBehaviour
{
    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;

    public string fullText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(TypeText());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TypeText()
    {
        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;

        for(int i = 0; i < textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
    }
}
