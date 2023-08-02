using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class AllBallSlider : MonoBehaviour{
    [SerializeField] private GameObject _slider;
    [SerializeField] private BallStateMonitor _ballStateMonitor;

    [SerializeField] private Cannon _cannon;

    private List<Sequence> _sequence;
    

    private bool[] isLaunchSpecial = new bool[3]{false,false,false};


    private void Awake() {
        StartCoroutine(SetSliderBallValue());

    }

    private IEnumerator SetSliderBallValue() {
        while (true) {
            UnityEngine.UI.Slider[] sl = _slider.GetComponents<Slider>();
            sl[0].value = _ballStateMonitor.AllBallCharged;
            yield return new WaitForSeconds(0.1f);
        }

    }
}