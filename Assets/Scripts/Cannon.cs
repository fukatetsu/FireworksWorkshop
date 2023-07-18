using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 花火の砲台。sequenceを入れ替えながらセットしていく
/// </summary>
public class Cannon
{

    /// <summary>
    /// sequenceの何発目まで発射したか
    /// </summary>
    private int _howManyExecution;
    public int HowManyExecution{
        get { return _howManyExecution ;}
        set { _howManyExecution = value; }
    }
    /// <summary>
    /// 何発まで発射できるか
    /// </summary>
    private int _maxExecution = 0;

    /// <summary>
    /// 装填されているシークエンス
    /// </summary>
    /// <value></value>
    private Sequence _sequence;
    public Sequence sequence{
        set { _sequence = value; }
        get {return this._sequence;}
    } 
    
    public Cannon(Transform sequence){
        _sequence = new Sequence(sequence);
        _howManyExecution = 0;
        _maxExecution = _sequence.SequenceLength();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset(){
        _howManyExecution = 0;
    }

    

    public void Launch(){
        if(_maxExecution > _howManyExecution){
            _sequence.Launch(_howManyExecution);
            _howManyExecution++;
        }
        
    }
    public void SetSequence(Transform sequence){
        _sequence = new Sequence(sequence);
        _howManyExecution = 0;
        _maxExecution = _sequence.SequenceLength();
    }
}
