using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickController))]
[RequireComponent(typeof(SelectionController))]
[RequireComponent(typeof(SpawningMode))]
[RequireComponent(typeof(WorkersController))]
public class GameController : MonoBehaviour {

    private TickController tickController;
    private SelectionController selectionController;
    private SpawningMode spawningMode;
    private WorkersController workersController;

    [SerializeField]
    private Map map;

    public TickController TickController { get { return tickController; } }
    public SelectionController SelectionController { get { return selectionController; } }
    public SpawningMode SpawningMode { get { return spawningMode; } }
    public WorkersController WorkersController { get { return workersController; } }

    public Map Map { get { return map; } }

    void Awake()
    {
        tickController = GetComponent<TickController>();
        selectionController = GetComponent<SelectionController>();
        spawningMode = GetComponent<SpawningMode>();
        workersController = GetComponent<WorkersController>();
    }


}
