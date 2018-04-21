using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class MaterialUser : MonoBehaviour {

    private ResourceGeneration materials;

    private MoneyUser moneyUser;
    private Unit unit;

    void Awake()
    {
        moneyUser = GetComponent<MoneyUser>();
        unit = GetComponent<Unit>();
        unit.OnTickEvent.AddListener(OnTick);
    }

    public void Initialize(GameController gameController, ResourceGeneration money, ResourceGeneration materials)
    {
        moneyUser.Initialize(gameController, money);

        this.materials = materials;
    }

    public void RenewMaterials(ResourceGeneration materials)
    {
        this.materials = materials;
    }

    private void OnTick()
    {
        if (materials != null)
        {
            if (materials.RemoveResource)
            {
                materials.Resource.ReduceAmount(materials.Amount);
            }
            else
            {
                materials.Resource.AddAmount(materials.Amount);
            }
        }
    }
}
