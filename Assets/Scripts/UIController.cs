using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIController : MonoBehaviour
{
    [SerializeField] GameObject _launchUI;
    private UIDocument _uiDocument;

    void Start()
    {
        // PrefabからUIを生成
        var buttonObject = Instantiate(_launchUI);
        
        // UIDocumentの参照を保存
        _uiDocument = buttonObject.GetComponent<UIDocument>();
    }
}