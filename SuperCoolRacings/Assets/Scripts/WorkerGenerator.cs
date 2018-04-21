using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Unit))]
public class WorkerGenerator : MonoBehaviour
{
    private Resource workers;

    public int AmountOfWorkers;

    private Unit unit;

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    public void Initialize(Resource workers, GameController controller)
    {
        unit.Initialize(controller);
        this.workers = workers;
        this.workers.AddAmount(AmountOfWorkers);
    }

    public void Demolish()
    {
        if (workers != null)
        {
            workers.ReduceAmount(AmountOfWorkers);
        }
    }
}
