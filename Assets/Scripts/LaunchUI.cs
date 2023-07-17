using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;


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

        AddSetSequenceButton(_baseElement.Q<GroupBox>("LeftCannon"));
        AddButtonEvent(_baseElement.Q<GroupBox>("LeftCannon"), 0);
        AddButtonEvent(_baseElement.Q<GroupBox>("CenterCannon"), 1);
        AddButtonEvent(_baseElement.Q<GroupBox>("RightCannon"), 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddButtonEvent(VisualElement visualElement, int num){
        var launchButton = visualElement.Q<Button>("LaunchButton");
        launchButton.clicked +=() =>
        {
            Debug.Log($"Cannon {num} : launch");
        };
        var resetButton = visualElement.Q<Button>("ResetButton");
        resetButton.clicked +=() =>
        {
            Debug.Log($"Cannon {num} : reset");
        };
        var chargeButton = visualElement.Q<Button>("ChargeButton");
        chargeButton.clicked +=() =>
        {
            Debug.Log($"Cannon {num} : charge");
        };
    }
    void AddSetSequenceButton(VisualElement visualElement){
        var setSequenceButton = new UnityEngine.UIElements.Button();
        setSequenceButton.name = "SetSequence";
        visualElement.Add(setSequenceButton);
        setSequenceButton.text = "Set Sequence";
    }

    
    
    
}
