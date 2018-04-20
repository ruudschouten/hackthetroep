using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Resource : MonoBehaviour {

    

    public int Amount;
    public int StartingAmount = 500;

    public UnityEvent OnValueChanged = new UnityEvent();

    public UnityEvent<int> OnValueChangedWithValue;

    void Awake()
    {
        Amount = StartingAmount;
        OnValueChangedWithValue = new ResourceWithValueEvent();
    }

    public void AddAmount(int amount)
    {
        Amount += amount;
        UpdateUI(amount);
    }

    public void ReduceAmount(int amount)
    {
        if (Amount >= amount)
        {
            Amount -= amount;

            UpdateUI(amount);
        }
    }

    private void UpdateUI(int amount)
    {
        OnValueChanged.Invoke();
        OnValueChangedWithValue.Invoke(amount);
    }

    public bool CanAfford(int cost)
    {
        return Amount >= cost;
    }
}

[System.Serializable]
public class ResourceWithValueEvent : UnityEvent<int>
{

}
