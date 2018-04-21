using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PollutionGenerator))]
[RequireComponent(typeof(WasteUser))]
[RequireComponent(typeof(MaterialUser))]
[RequireComponent(typeof(MoneyUser))]
[RequireComponent(typeof(WorkerSpender))]
[RequireComponent(typeof(Unit))]
public class WasteProcessor : MonoBehaviour {

    private ResourceGeneration pollutionPerTick;
    private ResourceGeneration wastePerTick;
    private ResourceGeneration materialsPerTick;
    private ResourceGeneration moneyPerTick;

    private PollutionGenerator pollutionGenerator;
    private WasteUser wasteUser;
    private MaterialUser materialUser;
    private MoneyUser moneyUser;
    private Unit unit;

    void Awake()
    {
        pollutionGenerator = GetComponent<PollutionGenerator>();
        wasteUser = GetComponent<WasteUser>();
        materialUser = GetComponent<MaterialUser>();
        moneyUser = GetComponent<MoneyUser>();
        unit = GetComponent<Unit>();
    }

    public void Initialize(GameController gameController,ResourceGeneration polluionPerTick, ResourceGeneration wastePerTick, ResourceGeneration materialsPerTick, ResourceGeneration moneyPerTick)
    {
        pollutionGenerator.Initialize(gameController, moneyPerTick, materialsPerTick, wastePerTick, pollutionPerTick);
    }
}
