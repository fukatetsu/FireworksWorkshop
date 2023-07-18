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
    private Cannon[] _cannon = new Cannon[3];

    public Cannon[] cannon { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < System.Math.Min(_sequences.Count,3); i++){
            _cannon[i] = new Cannon(_sequences[i]);
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
        _ballStateMonitor.Launch(num);
        _cannon[num].Launch();
    }
    public void Reset(int num){
        _ballStateMonitor.Reset(num);
        _cannon[num].Reset();
    }
}
