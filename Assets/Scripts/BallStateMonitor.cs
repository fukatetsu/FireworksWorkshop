using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStateMonitor : MonoBehaviour
{
    [SerializeField] private UdpReceiver[] udpReceiver = new UdpReceiver[3];
    private BallState[] ballState = new BallState[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 花火玉の状態をアップデートする
    /// </summary>
    /// <param name="num">BallStateの添え字</param>
    void BallUpdate(int num){
        float[] data = udpReceiver[num].GetData();
        ballState[num].acc = new Vector3(data[1], data[2], data[3]);
        ballState[num].avv = new Vector3(data[4], data[5], data[6]);
        ballState[num].rot = new Vector3(data[7], data[8], data[9]);
        ballState[num].qtn = new Quaternion(data[11], data[12], data[13], data[10]);
        ballState[num].ChargeEnergy();
        ballState[num].ChangeLEDColor();
    }

    /// <summary>
    /// 花火の発射
    /// </summary>
    /// <param name="num"></param>
    void Launch(int num){}
    
}

/// <summary>
/// 花火玉の状態を管理するクラス
/// </summary>
public class BallState{

    public Vector3 acc { get; set; }
    public Vector3 avv { get; set; }
    public Vector3 rot { get; set; }
    public Quaternion qtn { get; set; }
    public float chargedEnergy {get; set;}

    public void ChargeEnergy(){

    }

    public void ChangeLEDColor(){

    }

    public void Launch(){}


}