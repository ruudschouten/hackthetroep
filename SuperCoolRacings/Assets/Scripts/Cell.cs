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
        MarkQuad.SetActive(true);
    }

    public void UnmarkCell()
    {
        Marked = false;
        MarkQuad.SetActive(false);
    }

    private void OnMouseOver()
    {
        HoverQuad.SetActive(true);
    }

    private void OnMouseExit()
    {
        HoverQuad.SetActive(false);
    }
}
