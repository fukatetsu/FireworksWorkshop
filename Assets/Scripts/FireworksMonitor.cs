using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksMonitor : MonoBehaviour
{
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private List<Sequence> _sequences;
    [SerializeField] private Cannon[] _cannon = new Cannon[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 花火の発射
    /// </summary>
    void Launch(){

    }
}
