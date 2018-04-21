using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectionController : MonoBehaviour {

    public CellEvent SelectedCellEvent;

    public UnityEvent ClickedUIEvent = new UnityEvent();

    public UnityEvent ClickedNothingEvent = new UnityEvent();

    [HideInInspector]
    private Selectable currentSelected;

    public GameObject Selector;

    public Selectable CurrentSelected { get { return currentSelected; } }


    void Awake()
    {
        SelectedCellEvent = new CellEvent();
    }

    void Start()
    {
        MoveSelector();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (!EventSystem.current.IsPointerOverGameObject())
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    Selectable selectable = hit.transform.gameObject.GetComponent<Selectable>();

                    if (selectable != null)
                    {//Clicked Selectable

                        Cell selectedCell = selectable.GetComponent<Cell>();
                        if (selectedCell != null)
                        {//Clicked on a cell
                            SelectedCellEvent.Invoke(selectedCell);
                            SelectNewObject(null);
                        }
                        else
                        {
                            SelectNewObject(selectable);
                        }
                        

                    }
                    else
                    {//Clicked on something but not a selectable... ??

                    }
                }
                else
                {//Clicked on "nothing"
                    ClickedNothingEvent.Invoke();
                    SelectNewObject(null);
                }
            }
            else
            {//Clicked a UI element
                ClickedUIEvent.Invoke();
            }

        }

        MoveSelector();

    }

    private void MoveSelector()
    {
        if (Selector != null)
        {
            if (currentSelected != null)
            {
                Selector.gameObject.SetActive(true);
                Vector3 newPos = currentSelected.transform.position;
                newPos.y += currentSelected.SelectorHeight;
                Selector.transform.position = newPos;
            }
            else
            {
                Selector.gameObject.SetActive(false);
                Selector.transform.position = new Vector3(0, -10, 0);
            }
        }
        
    }

    private void SelectNewObject(Selectable selectable)
    {
        if (currentSelected != null)
        {
            currentSelected.Deselect();
        }

        currentSelected = selectable;

        if (currentSelected != null)
        {
            currentSelected.Select();
        }
    }

}

[System.Serializable]
public class CellEvent : UnityEvent<Cell>
{

}
