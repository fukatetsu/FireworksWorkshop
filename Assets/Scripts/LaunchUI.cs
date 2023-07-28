using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(UIDocument))]
public class LaunchUI : MonoBehaviour
{
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private FireworksMonitor _fireworksMonitor;

    
    
    private UIDocument _uiDocument;

    private VisualElement _baseElement;


    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = this.GetComponent<UIDocument>();
        _baseElement =  _uiDocument.rootVisualElement.Q<VisualElement>("Base");

        var rightElement = _baseElement.Q<GroupBox>("RightCannon");
        var leftElement = _baseElement.Q<GroupBox>("LeftCannon");
        var centerElement = _baseElement.Q<GroupBox>("CenterCannon");


        AddButtonEvent(leftElement, 0);
        AddButtonEvent(centerElement, 1);
        AddButtonEvent(rightElement, 2);

        // SetSequenceDropdownList(leftElement,0);
        // SetSequenceDropdownList(centerElement,1);
        // SetSequenceDropdownList(rightElement,2);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddButtonEvent(VisualElement visualElement, int num){
        var launchButton = visualElement.Q<Button>("LaunchButton");
        launchButton.clicked +=() =>
        {
            _fireworksMonitor.Launch(num);
        };
        var resetButton = visualElement.Q<Button>("ResetButton");
        resetButton.clicked +=() =>
        {
            _fireworksMonitor.Reset(num);
        };
        var chargeButton = visualElement.Q<Button>("ChargeButton");
        chargeButton.clicked +=() =>
        {
             _ballStateMonitor.BallState[num].BallCharge(10f);
        };
        var energyProgress = visualElement.Q<ProgressBar>("BallEnergy");
        energyProgress.schedule.Execute(() =>
        {
            energyProgress.value = _ballStateMonitor.HowCharged(num);
            // energyProgress.value += 1f;
        }).Every(10) ;
    }
    void AddBallChargeText(VisualElement visualElement, int num){
        var BallChargeText = new UnityEngine.UIElements.Button();
        BallChargeText.name = $"BallCharge_{num}";
        visualElement.Add(BallChargeText);
        BallChargeText.text = $"{num}";
    }

    // void SetSequenceDropdownList(VisualElement visualElement, int num){
    //     var dropdown = visualElement.Q<DropdownField>("SequenceDropdown");
    //     dropdown.choices.Clear();
    //     foreach(Transform sequence in _fireworksMonitor.sequences){
    //         dropdown.choices.Add($"{sequence.name}");


    //     }

    //     dropdown.index = num;

    //     dropdown.RegisterValueChangedCallback(evt =>
    //     {
    //         Debug.Log($"{evt.newValue}");
    //         foreach(Transform sequence in _fireworksMonitor.sequences){

    //         Debug.Log($"{sequence.name}");

    //             if(sequence.name == evt.newValue){
    //                 _fireworksMonitor.SetSequenceToCannon(num,sequence);
                    

    //             }
    //         }
    //         // if (EditorUtility.DisplayDialog("ドロップダウン", evt.newValue, "OK"))
    //         // {
    //         //     Debug.Log("Click");
    //         // }
    //     });
    // }
    
    
    
}
