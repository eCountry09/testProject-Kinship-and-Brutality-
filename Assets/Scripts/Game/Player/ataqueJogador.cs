using UnityEngine;
using System.Runtime.CompilerServices;

public class ataqueJogador : MonoBehaviour
{
    [SerializeField]
    private Transform pontoAtaque;
    private float raioAtaque;
    bool bAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X) && bAttack)
        {
            atacar();
        }
    }

    private void OnDrawGizmos()
    {
        if(this.pontoAtaque != null)
        {
            Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
            Gizmos.color = Color.red;
        }
    }

    void atacar()
    {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(this.pontoAtaque.position, this.raioAtaque);

        if(colliderInimigo != null)
        {
            bAttack = true;
            Sistema_inimigos inimigo = colliderInimigo.GetComponent<Sistema_inimigos>();

            if(inimigo != null)
            {
                inimigo.ReceberDano();
            }
        } else
        {
            bAttack = false;
        }
    }
}
