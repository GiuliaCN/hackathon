using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {

    private Animator anim;
    bool vivo = true;

    // Use this for initialization
    void Start () {
        anim = gameObject.GetComponent<Animator>();
        GameManager.gm.AtualizaHud();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PerdeVida()
    {
        if(vivo)
        {
            vivo = false;
        }
        anim.SetTrigger("Morreu");
        GameManager.gm.SetVidas(-1);
        this.gameObject.GetComponent<PlayerAtack>().enabled = false;
        this.gameObject.GetComponent<PlayerController>().enabled = false;



    }

    public void Reset()
    {
        if(GameManager.gm.GetVidas() >= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
