using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MaterialUser))]
[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class FactoryBuilding : MonoBehaviour {

    private ResourceGeneration materialsPerTick;
    private ResourceGeneration moneyPerTick;

    private MaterialUser materialUser;
    private Unit unit;
    private WorkerSpender workerSpender;

    private MoneyUser moneyUser;

    private Resource materials;

    private int maxMaterials;
    private int maxMoney;

    private bool useMaterials = false;

    private float effectiveness = 1;

    private ShopBooster shopBooster;

    void Awake()
    {
        materialUser = GetComponent<MaterialUser>();
        unit = GetComponent<Unit>();
        moneyUser = GetComponent<MoneyUser>();
        workerSpender = GetComponent<WorkerSpender>();

        workerSpender.OnEffectivenessChanged.AddListener(RecalculateEffectiveness);
    }

    void Start()
    {

        shopBooster = unit.GameController.ShopBooster;

    }

    public void Initialize(Resource materials, GameController gameController, ResourceGeneration materialsPerTick, ResourceGeneration moneyPerTick)
    {
        this.materials = materials;
        this.materialsPerTick = materialsPerTick;
        this.moneyPerTick = moneyPerTick;
        materialUser.Initialize(gameController, moneyPerTick, materialsPerTick);

        maxMaterials = materialsPerTick.Amount;
        maxMoney = moneyPerTick.Amount;
    }

    [ContextMenu("UseMaterials")]
    public void SetModeToMaterials()
    {
        useMaterials = true;

        shopBooster.AddBoost();

        RecalculateEffectiveness(effectiveness);
    }

    [ContextMenu("BuyMaterials")]
    public void SetModeToBuy()
    {
        useMaterials = false;

        shopBooster.RemoveBoost();

        RecalculateEffectiveness(effectiveness);
    }

    private void RecalculateEffectiveness(float effectiveness)
    {
        this.effectiveness = effectiveness;

        if (useMaterials)
        {

        }
        else
        {

        }

        materialsPerTick.Amount = (int)(maxMaterials / effectiveness);
        moneyPerTick.Amount = (int)(maxMoney / effectiveness);
    }

}
