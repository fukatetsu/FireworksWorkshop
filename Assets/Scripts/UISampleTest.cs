using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class UISampleTest : MonoBehaviour{

    [SerializeField] private List<GameObject> _CannonUI;
    [SerializeField] private BallStateMonitor _ballStateMonitor;
    [SerializeField] private FireworksMonitor _fireworksMonitor;

    private List<Dropdown.OptionData> _sequenceOptions = new List<Dropdown.OptionData>();

    private void Awake() {
        for(int i = 0; i < _CannonUI.Count; i++){
            StartCoroutine(SetChargeText(_CannonUI[i].transform.Find("ChargeProgress").gameObject, i));
            StartCoroutine(SetLaunchText(_CannonUI[i].transform.Find("Launch").gameObject, i));

        }
    }



    private IEnumerator  SetChargeText(GameObject chargeProgress, int num){
        while(true){

        UnityEngine.UI.Text[] text = chargeProgress.GetComponentsInChildren<Text>();
        text[0].text = $"{_ballStateMonitor.BallState[num].HowCharged}";
        yield return new WaitForSeconds(0.5f);
        }
    }
    private IEnumerator  SetLaunchText(GameObject launchButton, int num){
        while(true){

            UnityEngine.UI.Button[] Button = launchButton.GetComponents<Button>();
            Button[0].interactable = _ballStateMonitor.BallState[num].IsCharged;
            yield return new WaitForSeconds(0.5f);
        }
    }

    // void SetSequenceDropdownList(GameObject dropdownElement, int num){
    //     UnityEngine.UI.Dropdown dropdown = dropdownElement.GetComponents<Dropdown>()[0];
    //     dropdown.ClearOptions();
    //     foreach(Transform sequence in _fireworksMonitor.sequences){
    //         // dropdown.AddOptions($"{sequence.name}");


    //     }

    //     // dropdown.index = num;

    //     // dropdown.RegisterValueChangedCallback(evt =>
    //     // {
    //     //     Debug.Log($"{evt.newValue}");
    //     //     foreach(Transform sequence in _fireworksMonitor.sequences){

    //     //     Debug.Log($"{sequence.name}");

    //     //         if(sequence.name == evt.newValue){
    //     //             _fireworksMonitor.SetSequenceToCannon(num,sequence);
                    

    //     //         }
    //     //     }
    //     //     // if (EditorUtility.DisplayDialog("ドロップダウン", evt.newValue, "OK"))
    //     //     // {
    //     //     //     Debug.Log("Click");
    //     //     // }
    //     // });
    // }
}