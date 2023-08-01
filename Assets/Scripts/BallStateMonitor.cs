using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-5)]
public class BallStateMonitor : MonoBehaviour
{
    [SerializeField] private UdpReceiver[] udpReceiver = new UdpReceiver[3];
    private BallState[] _ballState;
    public BallState[] BallState{
        get { return _ballState; }
    }
    // Start is called before the first frame update

    // BallStateMonitor(){
    //     _ballState = new BallState[3];
    //     for(int i = 0; i < _ballState.Length; i++){

    //         _ballState[i] = new BallState();
    //     }
    // }

    void Awake(){
        _ballState = new BallState[3];
        for(int i = 0; i < _ballState.Length; i++){

            _ballState[i] = new BallState();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < udpReceiver.Length; i++){
            BallUpdate(i);
        }
    }


    /// <summary>
    /// 花火玉の状態をアップデートする
    /// </summary>
    /// <param name="num">BallStateの添え字</param>
    void BallUpdate(int num){
        float[] data = udpReceiver[num].GetData();
        var acc = new Vector3(data[1], data[2], data[3]).magnitude;
        if(acc > 1.5){

            _ballState[num].BallCharge(acc/100);
        }else{
            // _ballState[num].BallCharge(0.1f/100);
        }


    } 

    /// <summary>
    /// 花火の発射
    /// </summary>
    /// <param name="num"></param>
    public void Launch(int num){
        _ballState[num].ResetBallCharge();
    }
    public void Reset(int num){
        _ballState[num].ResetBallCharge();
    }

    public float HowCharged(int num){
        return _ballState[num].HowCharged;
    }
    public void BallChargeFromButton(int num ){
        _ballState[num].BallCharge(100);
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
    /// <summary>
    /// ボールに花火を発射できるだけのエネルギーが溜まっているか
    /// </summary>
    private bool _isCharged;
    public bool IsCharged {
        get { return _isCharged;}
        set{ this._isCharged = value;}
    }

    public BallState(){
       _howCharged = 0.0f;
       _isCharged = true;
    }

    /// <summary>
    /// ボールにエネルギーをためる
    /// </summary>
    /// <param name="charge">エネルギーをためる量</param>
    public void BallCharge(float charge){
        _howCharged += charge;
        if(_howCharged >=100){
            _isCharged = true;
        }
    }
    /// <summary>
    /// 溜まったエネルギーをリセットする
    /// </summary>
    public void ResetBallCharge(){
        _howCharged = 0.0f;
        _isCharged = true;
        Debug.Log($"Ball was reset");

    }






}