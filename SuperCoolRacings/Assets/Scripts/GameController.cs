using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickController))]
[RequireComponent(typeof(SelectionController))]
[RequireComponent(typeof(SpawningMode))]
public class GameController : MonoBehaviour {

    private TickController tickController;
    private SelectionController selectionController;
    private SpawningMode spawningMode;

    public TickController TickController { get { return tickController; } }
    public SelectionController SelectionController { get { return selectionController; } }
    public SpawningMode SpawningMode { get { return spawningMode; } }

    void Awake()
    {
        tickController = GetComponent<TickController>();
        selectionController = GetComponent<SelectionController>();
        spawningMode = GetComponent<SpawningMode>();
    }


}
