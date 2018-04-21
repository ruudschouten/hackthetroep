using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Selectable))]
public class Cell : MonoBehaviour {

    public int X;
    public int Y;

    public GameObject MarkQuad;
    public GameObject HoverQuad;

    public bool Marked = false;

    public bool IsOccupied()
    {
        Unit unit = GetComponentInChildren<Unit>();
        return (unit != null);
    }

    public void MarkCell()
    {
        Marked = true;
        if (MarkQuad != null)
        {
            MarkQuad.SetActive(true);
        }
    }

    public void UnmarkCell()
    {
        Marked = false;
        if (MarkQuad != null)
        {
            MarkQuad.SetActive(false);
        }
    }

    private void OnMouseOver()
    {
        if (HoverQuad != null)
        {
            HoverQuad.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (HoverQuad != null)
        {
            HoverQuad.SetActive(false);
        }
    }
}
