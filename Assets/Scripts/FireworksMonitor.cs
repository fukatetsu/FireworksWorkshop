using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksMonitor : MonoBehaviour
{
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private List<Transform> _centerSequences;
    [SerializeField] private List<Transform> _leftSequences;
    [SerializeField] private List<Transform> _rightSequences;
    [SerializeField] private List<Transform> _specialSequences;

    [SerializeField] private List<Material> _centerMaterial;
    [SerializeField] private List<Material> _leftMaterial;
    [SerializeField] private List<Material> _rightMaterial;
    [SerializeField] private List<Material> _specialMaterial;
    [SerializeField] private List<Cannon> _cannon;

    public List<Cannon> Cannon { get; set; }
    private int[] _cannonSequenceNum = new int []{0,0,0};

    [SerializeField] Cannon _specialCannon;

    private bool[] didLaunchSpecial = new bool[3]{false,false,false};

    public bool[] DidLaunchSpecial { get {return didLaunchSpecial;} }
    private int nowSpecial = 0;

    // Start is called before the first frame update
    void Start()
    {
        _cannon[0].SetSequence(_leftSequences[0]);
        _cannon[2].SetSequence(_rightSequences[0]);
        _cannon[1].SetSequence(_centerSequences[0]);
        _specialCannon.SetSequence(_specialSequences[0]);

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

            _cannon[num].Launch(_ballStateMonitor.HowCharged(num)/12);
            if(_cannon[num].MaxExecution == _cannon[num].HowManyExecution){
                _cannon[num].Reset();
                _ballStateMonitor.Launch(num);
            }
        }
    }

    public void LaunchSpecial(int num){
        if(_ballStateMonitor.AllBallCharged >= (num +1) * 500 && didLaunchSpecial[num] == false){
            if(nowSpecial != num){
                nowSpecial = num;
                _specialCannon.SetSequence(_specialSequences[num]);
            }

            _specialCannon.Launch(3);
            
            if(_specialCannon.MaxExecution == _specialCannon.HowManyExecution){
                _specialCannon.Reset();
                didLaunchSpecial[num] = true;
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

    public void SetLeftSequenceToCannon(int num){
        _cannon[0].SetSequence(_leftSequences[num]);
    }
    public void SetCenterSequenceToCannon(int num){
        _cannon[1].SetSequence(_centerSequences[num]);
    }
    public void SetRightSequenceToCannon(int num){
        _cannon[2].SetSequence(_rightSequences[num]);
    }
    public void SetNextSequenceToCannon(int cannonNum){

        switch(cannonNum){
            case 0:
                    Debug.Log("testleft2");
                
                _cannonSequenceNum[cannonNum]++;
                if(_leftSequences.Count > _cannonSequenceNum[cannonNum]){
                    Debug.Log($"{_leftSequences.Count}>{_cannonSequenceNum[cannonNum]}");
                    _cannon[cannonNum].SetSequence(_leftSequences[_cannonSequenceNum[cannonNum]]);
                    
                }
                break;
            case 2:
                _cannonSequenceNum[cannonNum]++;
                if(_centerSequences.Count > _cannonSequenceNum[cannonNum]){
                    Debug.Log($"{_centerSequences.Count}>{_cannonSequenceNum[cannonNum]}");
                    
                    _cannon[cannonNum].SetSequence(_rightSequences[_cannonSequenceNum[cannonNum]]);
                }
                break;
            case 1:
                _cannonSequenceNum[cannonNum]++;
                if(_rightSequences.Count > _cannonSequenceNum[cannonNum]){
                    Debug.Log($"{_rightSequences.Count}>{_cannonSequenceNum[cannonNum]}");
                    
                    _cannon[cannonNum].SetSequence(_centerSequences[_cannonSequenceNum[cannonNum]]);
                }
                break;

        }

    }
}
