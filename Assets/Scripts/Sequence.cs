using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Sequence
{


    private List<Transform> _fireworks = new List<Transform>();


    public Sequence(Transform transform, Vector3 position){
        foreach (Transform childObject in transform)
        {
             _fireworks.Add(childObject); 
             _fireworks.Last().transform.position = position; 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// num番目の花火の発射
    /// </summary>
    /// <param name="num">添え字</param>
    public void Launch(int num, float charge){
        if(num < _fireworks.Count){
             ParticleSystem particle = _fireworks[num].GetComponent<ParticleSystem>();
            var em = particle.emission;
            em.enabled = true;
            em.rateOverTime = charge;
            particle.Play();
        }

    }

    /// <summary>
    /// シークエンスの長さを返す
    /// </summary>
    /// <returns>シークエンスの長さ</returns>
    public int SequenceLength(){
        return _fireworks.Count;
    }
}
