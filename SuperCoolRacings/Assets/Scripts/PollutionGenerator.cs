using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WasteUser))]
[RequireComponent(typeof(MaterialUser))]
[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class PollutionGenerator : MonoBehaviour {

    private ResourceGeneration pollution;

    private WasteUser wasteUser;
    private Unit unit;

    void Awake()
    {
        wasteUser = GetComponent<WasteUser>();
        unit = GetComponent<Unit>();
        unit.OnTickEvent.AddListener(OnTick);
    }

    public void Initialize(GameController gameController, ResourceGeneration money, ResourceGeneration materials, ResourceGeneration waste, ResourceGeneration pollution)
    {
        wasteUser.Initialize(gameController, money, materials, waste);

        this.pollution = pollution;
    }

    public void RenewPollution(ResourceGeneration pollution)
    {
        this.pollution = pollution;
    }

    private void OnTick()
    {
        if (pollution != null)
        {
            if (pollution.RemoveResource)
            {
                pollution.Resource.ReduceAmount(pollution.Amount);
            }
            else
            {
                pollution.Resource.AddAmount(pollution.Amount);
            }
        }
    }
}
