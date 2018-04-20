using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Resource))]
public class UIResource : MonoBehaviour {
    
    public Text Value;

    private Resource resource;

    public void Start()
    {
        resource = GetComponent<Resource>();
        UpdateUI();
        resource.OnValueChanged.AddListener(UpdateUI);
    }


    public void UpdateUI()
    {
        Value.text = resource.Amount.ToString();
    }
}
