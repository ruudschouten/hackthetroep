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
    private ResourceGeneration moneyPerTickIncinerate;
    private ResourceGeneration moneyPerTickStore;
    private ResourceGeneration moneyPerTickRecycle;

    private ResourceGeneration moneyPerTick;

    private GameController gameController;

    private PollutionGenerator pollutionGenerator;
    private WasteUser wasteUser;
    private MaterialUser materialUser;
    private MoneyUser moneyUser;
    private Unit unit;

    private int maxPollution;
    private int maxWaste;
    private int maxMaterials;

    private int maxMoneyIncinerate;
    private int maxMoneyStore;
    private int maxMoneyRecycle;

    private ProcessType processType = ProcessType.Store;
    private float effectiveness = 1;

    private WorkerSpender workerSpender;

    void Awake()
    {
        pollutionGenerator = GetComponent<PollutionGenerator>();
        wasteUser = GetComponent<WasteUser>();
        materialUser = GetComponent<MaterialUser>();
        moneyUser = GetComponent<MoneyUser>();
        unit = GetComponent<Unit>();
        workerSpender = GetComponent<WorkerSpender>();

        workerSpender.OnEffectivenessChanged.AddListener(CalculateValues);
    }

    public void Initialize(GameController gameController,ResourceGeneration pollutionPerTick, ResourceGeneration wastePerTick, ResourceGeneration materialsPerTick, ResourceGeneration moneyPerTickIncinerate, ResourceGeneration moneyPerTickStore, ResourceGeneration moneyPerTickRecycle)
    {

        this.pollutionPerTick = pollutionPerTick;
        this.wastePerTick = wastePerTick;
        this.materialsPerTick = materialsPerTick;

        moneyPerTick = moneyPerTickStore;

        this.gameController = gameController;
        
        maxPollution = pollutionPerTick.Amount;
        maxWaste = wastePerTick.Amount;
        maxMaterials = materialsPerTick.Amount;

        maxMoneyIncinerate = moneyPerTickIncinerate.Amount;
        maxMoneyStore = moneyPerTickStore.Amount;
        maxMoneyRecycle = moneyPerTickRecycle.Amount;

        this.moneyPerTickIncinerate = moneyPerTickIncinerate;
        this.moneyPerTickStore = moneyPerTickStore;
        this.moneyPerTickRecycle = moneyPerTickRecycle;

        pollutionGenerator.Initialize(gameController, moneyPerTick, materialsPerTick, wastePerTick, pollutionPerTick);
        CalculateValues(effectiveness);
    }

    [ContextMenu("SetIncinerate")]
    public void SetModeToIncinerate()
    {
        processType = ProcessType.Incinerate;
        CalculateValues(effectiveness);
    }

    [ContextMenu("SetRecycle")]
    public void SetModeToRecycle()
    {
        processType = ProcessType.Recycle;
        CalculateValues(effectiveness);
    }

    [ContextMenu("SetStore")]
    public void SetModeToStore()
    {
        processType = ProcessType.Store;
        CalculateValues(effectiveness);
    }

    private void CalculateValues(float effectiveness)
    {
        this.effectiveness = effectiveness;

        switch (processType)
        {
            case ProcessType.Incinerate:

                moneyPerTick.Amount = (int)(maxMoneyIncinerate * effectiveness);

                pollutionPerTick.Amount = (int)(maxPollution * effectiveness);

                materialsPerTick.Amount = 0;

                wastePerTick.Amount = (int)(maxWaste * effectiveness);

                break;
            case ProcessType.Store:

                moneyPerTick.Amount = (int)(maxMoneyStore * effectiveness);

                pollutionPerTick.Amount = 0;

                materialsPerTick.Amount = 0;

                wastePerTick.Amount = (int)(maxWaste * effectiveness);

                break;
            case ProcessType.Recycle:

                moneyPerTick.Amount = (int)(maxMoneyRecycle * effectiveness);

                pollutionPerTick.Amount = 0;

                materialsPerTick.Amount = (int)(maxMaterials * effectiveness);

                wastePerTick.Amount = (int)(maxWaste * effectiveness);

                break;
            default:
                break;
        }
    }

    public enum ProcessType
    {
        Incinerate,
        Store,
        Recycle
    }
}
