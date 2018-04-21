using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class WasteGenerator : MonoBehaviour {

    private ResourceGeneration waste;

    private MoneyUser moneyUser;
    private Unit unit;

    void Awake()
    {
        moneyUser = GetComponent<MoneyUser>();
        unit = GetComponent<Unit>();
        unit.OnTickEvent.AddListener(OnTick);


    }

    void Start()
    {
        unit.GameController.ShopBooster.ShopBoostChanged.AddListener(ShopBoostChanged);
    }

    private void ShopBoostChanged(int level)
    {

    }

    public void Initialize(GameController gameController, ResourceGeneration money, ResourceGeneration waste)
    {
        moneyUser.Initialize(gameController, money);

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
