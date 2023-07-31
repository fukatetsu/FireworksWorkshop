using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksMonitor : MonoBehaviour
{
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private List<Transform> _centerSequences;
    [SerializeField] private List<Transform> _leftSequences;
    [SerializeField] private List<Transform> _rightSequences;
    [SerializeField] private List<Cannon> _cannon;

    public List<Cannon> Cannon { get; set; }

    private int[] _cannonSequenceNum;

    // Start is called before the first frame update
    void Start()
    {
        _cannonSequenceNum = new int []{0,0,0};
        _cannon[0].SetSequence(_leftSequences[0]);
        _cannon[1].SetSequence(_rightSequences[0]);
        _cannon[2].SetSequence(_centerSequences[0]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 花火の発射
    /// </summary>
    public void Launch(int num){
        Debug.Log($"Launch button {num}");
        if(_ballStateMonitor.BallState[num].IsCharged){

            _cannon[num].Launch();
            if(_cannon[num].MaxExecution == _cannon[num].HowManyExecution){
                _cannon[num].Reset();
                _ballStateMonitor.Launch(num);
            }
        }
    }
    public void Reset(int num){
        _ballStateMonitor.Reset(num);
        _cannon[num].Reset();
    }
    public void SetSequenceToCannon(int cannonNum, Transform transform){
        _cannon[cannonNum].SetSequence(transform);
    }
    public void SetNextSequenceToCannon(int cannonNum){

        switch(cannonNum){
            case 0:

                _cannonSequenceNum[cannonNum]++;
                if(_leftSequences.Count > _cannonSequenceNum[cannonNum]){

                    _cannon[cannonNum].SetSequence(_leftSequences[_cannonSequenceNum[cannonNum]]);
                    
                }
                break;
            case 1:
                _cannonSequenceNum[cannonNum]++;
                if(_centerSequences.Count > _cannonSequenceNum[cannonNum]){
                    
                    _cannon[cannonNum].SetSequence(_rightSequences[_cannonSequenceNum[cannonNum]]);
                }
                break;
            case 2:
                _cannonSequenceNum[cannonNum]++;
                if(_rightSequences.Count > _cannonSequenceNum[cannonNum]){
                    
                    _cannon[cannonNum].SetSequence(_centerSequences[_cannonSequenceNum[cannonNum]]);
                }
                break;

        }

    }
}
