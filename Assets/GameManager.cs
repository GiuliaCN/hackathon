using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    private int vidas = 2;

	// Awake inicia momentos antes do objeto aparecer na tela != Start (começa quando o objeto aparece)
	void Awake () {
		if(gm == null)
        {
            gm = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
	}

    void Start()
    {

        AtualizaHud();

    }

    // Update is called once per frame
    void Update () {
	}

    public void SetVidas(int vida)
    {   
        vidas += vida; //nao confundir parametro com atributo
        if (vidas >= 0)
        {
            AtualizaHud();
        }
    }

    public int GetVidas()
    {
        return vidas;
    }

    public void AtualizaHud()
    {
        //GameObject.Find("VidasText").GetComponent<Text>().text = vidas.ToString();
        //Devemos fazer os coraçõeszinhos sumirem
    }

    
}
