using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LifeController : MonoBehaviour
{
    [SerializeField]
    Text vida, score;
    int vidas = 3, puntos = 0;
    public int Vidas
    {
        set { vidas -= value; }
    }
    public int Puntos
    {
        get { return puntos; }
        set { puntos += value; }
    }

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (puntos < 5)
        {
            vida.text = "Vidas: " + vidas.ToString();
            score.text = "Puntos: " + puntos.ToString();
        }
        else
        {
            vida.text = "Vidas: Ganaste";
            score.text = "Puntos: Ganaste";
        }
        
        if (vidas<=0)
        {
            SceneManager.LoadScene("test");
        }
    }
  
}
