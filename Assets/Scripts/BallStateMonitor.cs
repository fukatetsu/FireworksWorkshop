using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStateMonitor : MonoBehaviour
{
    [SerializeField] private UdpReceiver[] udpReceiver = new UdpReceiver[3];
    private BallState[] _ballState = new BallState[3];

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
        _ballState[num].BallCharge(new Vector3(data[1], data[2], data[3]).magnitude);

    }

    /// <summary>
    /// 花火の発射
    /// </summary>
    /// <param name="num"></param>
    void Launch(int num){
        _ballState[num].ResetBallCharge();
    }
    
}

/// <summary>
/// 花火玉の状態を管理するクラス
/// </summary>
public class BallState{

    /// <summary>
    /// エネルギーがどれくらい溜まっているか
    /// </summary>
    private float _howCharged;

    public float HowCharged { 
        get { return _howCharged; }
        set { this._howCharged = value; }
    }
    
    BallState(){
       _howCharged = 0.0f;
    }

    /// <summary>
    /// ボールにエネルギーをためる
    /// </summary>
    /// <param name="charge">エネルギーをためる量</param>
    public void BallCharge(float charge){
        _howCharged += charge;
    }
    /// <summary>
    /// 溜まったエネルギーをリセットする
    /// </summary>
    public void ResetBallCharge(){
        _howCharged = 0.0f;
    }

    /// <summary>
    /// ボールに花火を発射できるだけのエネルギーが溜まっているか
    /// </summary>
    public bool IsCharged(){
        return true;
    }       



}