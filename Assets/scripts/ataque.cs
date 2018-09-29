using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo.cs : MonoBehaviour {
    public float forcaHorizontal = 15; //quando ataca, inimigo vai para cima e eh empurrado
public float forcaVertical = 10;
public float tempoDestruicao = 1;
public float forcaHorizontalPadrao;
// Use this for initialization
void Start()
{
    forcaHorizontalPadrao = forcaHorizontal;
}

// Update is called once per frame
void Update()
{

}
void OnTrigger(Collider2D other)
{
    if (other.gameObject.CompareTag("Enemy"))
    {
        other.gameObject.GetComponent<Enemy>().enable = false;

        BoxCollider2D[] boxes = other.gameObject.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D box in boxes)
        {
            box.enabled = false;
        }

        if (other.transform.position.x < transform.position.x)
            forcaHorizontal *= -1; //dependendo de onde esta o inimigo inverte para onde vai impulso

        other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(forcaHorizontal, forcaVertical), ForceMode2D.Impulse);

        Destroy(other.gameObject, tempoDestruicao);

        forcaHorizontal = forcaHorizontalPadrao;
    }
}
}