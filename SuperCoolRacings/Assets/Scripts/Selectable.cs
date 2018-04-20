using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Selectable : MonoBehaviour {

    public UnityEvent OnSelected = new UnityEvent();
    public UnityEvent OnDeselected = new UnityEvent();

    public float SelectorHeight;

    void Awake()
    {

    }

    public void Select()
    {
        OnSelected.Invoke();
    }

    public void Deselect()
    {
        OnDeselected.Invoke();
    }
}
