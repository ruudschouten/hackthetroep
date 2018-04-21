using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MaterialUser))]
[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class WasteUser : MonoBehaviour {

    private ResourceGeneration waste;

    private MaterialUser materialUser;
    private Unit unit;

    void Awake()
    {
        materialUser = GetComponent<MaterialUser>();
        unit = GetComponent<Unit>();
        unit.OnTickEvent.AddListener(OnTick);
    }

    public void Initialize(GameController gameController, ResourceGeneration money, ResourceGeneration materials, ResourceGeneration waste)
    {
        materialUser.Initialize(gameController, money, materials);

        this.waste = waste;
    }

    public void RenewWaste(ResourceGeneration waste)
    {
        this.waste = waste;
    }

    private void OnTick()
    {
        if (waste != null)
        {
            if (waste.RemoveResource)
            {
                waste.Resource.ReduceAmount(waste.Amount);
            }
            else
            {
                waste.Resource.AddAmount(waste.Amount);
            }
        }
    }
}
