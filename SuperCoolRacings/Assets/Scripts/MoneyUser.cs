using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class MoneyUser : MonoBehaviour {

    private Unit unit;
    private WorkerSpender workerSpender;

    private ResourceGeneration money;

    void Awake()
    {
        unit = GetComponent<Unit>();
        workerSpender = GetComponent<WorkerSpender>();
        unit.OnTickEvent.AddListener(OnTick);
    }

    public void Initialize(GameController gameController, ResourceGeneration money)
    {
        workerSpender.Initialize(gameController);
        this.money = money;
    }

    public void RenewMoney(ResourceGeneration money)
    {
        this.money = money;
    }

    private void OnTick()
    {
        if (money != null)
        {

            if (money.RemoveResource)
            {
                money.Resource.ReduceAmount(money.Amount);
            }
            else
            {
                money.Resource.AddAmount(money.Amount);
            }
        }
    }
}
