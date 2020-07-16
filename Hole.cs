using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public enum MoleState
    {
        Ready,
        None,//시작할때 구멍상태
        Open,//나오기 시작
        Idle,//다나옴 (이때 터치 하여 잡기가능)
        Close,//점수획득불가능상태
        Catch //잡았을때
    }
    GameObject gc;
    public MoleState MS;
    int point = 5;
    float wait;
    float maxWait = 5.5f;
    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        gc = GameObject.Find("GM");
        wait = Random.Range(0.5f,maxWait);
        anim = GetComponent<Animator>();
        MS = MoleState.None;
       
    }



    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;

        if (wait <= 0&& MS == MoleState.None)
        {
            OpenMole();
        }

        if (gc.GetComponent<GM>().score == 100)
        {
            maxWait = 1.0f;
        }
       
    }

    void OpenMole()
    {
        MS = MoleState.Open;
        anim.Play("up");

    }
    private void OnMouseDown()
    {
        if(MS == MoleState.Idle)
        {
            anim.Play("hit");
            MS = MoleState.Catch;
            gc.GetComponent<GM>().AddPoint(point);
           
        }
    }
    public void SetIdle()
    {
        MS = MoleState.Idle;
    }
    public void setClose()
    {
        MS = MoleState.Close;
    }
    public void CloseMole()
    {
        MS = MoleState.None;
       wait = Random.Range(0.5f, maxWait);
    }
}
