using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
    [SerializeField]
    int vidaBloque;
    LifeController vida;
	// Use this for initialization
	void Start () {
        vida = GameObject.Find("Ball").GetComponent<LifeController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            vidaBloque--;
            if (vidaBloque <= 0)
            {
                vida.Puntos = vidaBloque * 2;
                Destroy(this.gameObject);
            }
        }
    }
}
