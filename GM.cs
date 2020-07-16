using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    public static GM manager;
    public  int score;
    public Text scoreText;
    public float wait;
   
    

   
    public void  AddPoint(int value)
    {
        score += value;
    }
    public void setGameOver()
    {
        //게임오버
    }
    public void setReplay()
    {
        //리플레이
    }
    // Start is called before the first frame update
    void Start()
    {
       
        score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
