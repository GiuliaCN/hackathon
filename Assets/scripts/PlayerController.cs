using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 5f;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool jump = false;
    
    private Animator anim;
    private bool noChao = false; // so pular quando estiver no chao
    private Transform groundCheck;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        groundCheck = gameObject.transform.Find("GroundCheck");

    }

    // Update is called once per frame
    void Update()
    {
        //checar a posição do ground check, se o objeto estiver na layer ground, noChao = true -> pode pular
        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        if (Input.GetKeyUp(KeyCode.UpArrow) && noChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jump = true;
            anim.SetTrigger("Pulou");
        }
        //verificar se abaixou
        float abaixou = Input.GetAxisRaw("Vertical");
        if(abaixou < 0)
        {
            anim.SetBool("Abaixou", true);
        } else
        {
            anim.SetBool("Abaixou", false);
        }

    }
    private void FixedUpdate()
    {
        //"Horizontal" = setas do teclado direita(1) esquerda(-1) -> AxisRaw define se é -1 ou 1
        float h = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("Velocidade", Mathf.Abs(h)); //o valor do negativo fica positivo com Mathf. Velocidade = h
        rb.velocity = new Vector2(h * speed, rb.velocity.y); //no eixo x é multiplicada por h, no eixo y fica constante
        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale; //criar variavel TheScale, armazena 3 valores (vector3)
        theScale.x *= -1; //mudar o scale do x (PARA INVERTER O PERSONAGEM EM RELAÇÃO A HORIZONTAL), scale y não muda
        transform.localScale = theScale;
    }
}

