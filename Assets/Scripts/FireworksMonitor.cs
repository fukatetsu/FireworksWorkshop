using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksMonitor : MonoBehaviour
{
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private List<Transform> _sequences;
    public List<Transform> sequences{
        get { return _sequences;}
    }
    [SerializeField] private List<Cannon> _cannon;

    public Cannon[] cannon { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < System.Math.Min(_sequences.Count,3); i++){
            _cannon[i].SetSequence(_sequences[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 花火の発射
    /// </summary>
    public void Launch(int num){
        _cannon[num].Launch();
        if(_cannon[num].MaxExecution == _cannon[num].HowManyExecution){
            _ballStateMonitor.Launch(num);
        }
    }
    public void Reset(int num){
        _ballStateMonitor.Reset(num);
        _cannon[num].Reset();
    }
    public void SetSequenceToCannon(int cannonNum, Transform transform){
        _cannon[cannonNum].SetSequence(transform);
    }
}
