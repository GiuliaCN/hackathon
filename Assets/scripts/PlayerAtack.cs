using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour {

    public float intervaloDeAtaque;
    private float proximoAtaque;
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space) && Time.time > proximoAtaque)
        {
            Atacando();
        }
	}

    void Atacando()
    {
        anim.SetTrigger("Atacou");
        proximoAtaque = Time.time + intervaloDeAtaque; //Time.time= tempo atual de jogo!
    }
}
