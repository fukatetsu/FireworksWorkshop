using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;





public class Launch : MonoBehaviour
{
    [SerializeField] GameObject launcher;

    private List<Transform> _sequence = new List<Transform>();
    private List<int> _launchNum = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform childObject in launcher.transform)
        {
             _sequence.Add(childObject); 
            _launchNum.Add(0);
        }
        LaunchFireworks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private  async void LaunchFireworks(){

        for(int i = 0; i < _sequence.Count; i++){
            _sequence[i].GetComponent<ParticleSystem>().Play();
            await Task.Delay(5000);
        }    


    }
}
