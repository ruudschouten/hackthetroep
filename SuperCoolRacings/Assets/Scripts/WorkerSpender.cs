using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Unit))]
public class WorkerSpender : MonoBehaviour {

    public int RequiredWorkers;

    public EffectivenessEvent OnEffectivenessChanged = new EffectivenessEvent();

    private int assignedWorkers;

    private Unit unit;

    


    public int AssignedWorkers
    { set
        {
            int workers = value;
            if (workers < 0)
            {
                workers = 0;
            }
            else if(workers > RequiredWorkers)
            {
                workers = RequiredWorkers;
            }

            assignedWorkers = workers;
            OnEffectivenessChanged.Invoke(CalculateEffectiveness());
        }
    }

    void Awake()
    {
        unit = GetComponent<Unit>();
    }

    private float CalculateEffectiveness()
    {
        if (RequiredWorkers != 0)
        {
            return assignedWorkers / RequiredWorkers;
        }
        else
        {
            return 1;
        }
    }

    public void Initialize(GameController gameController)
    {
        unit.Initialize(gameController);
        unit.GameController.WorkersController.RegisterWorkerSpender(this);
    }

    public void Demolish()
    {
        unit.GameController.WorkersController.RemoveWorkerSpender(this);
    }

}

[System.Serializable]
public class EffectivenessEvent : UnityEvent<float>
{

}
