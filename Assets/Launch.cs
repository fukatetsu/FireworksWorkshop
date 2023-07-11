using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class Launch : MonoBehaviour
{
    [SerializeField] GameObject launcher;

    private List<Transform> _sequence;
    private List<int> _launchNum;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childObject in launcher.transform)
        {
             _sequence.Add(childObject); 
            _launchNum.Add(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < _sequence.Count; i++){
        }
    }

    void LaunchFireworks(){

        _sequence[i].GetComponent<ParticleSystem>().Play();
        


    }
}
