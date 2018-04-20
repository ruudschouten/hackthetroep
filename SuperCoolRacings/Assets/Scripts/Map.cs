using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    [SerializeField]
    private int sizeX;
    [SerializeField]
    private int sizeY;

    [SerializeField]
    private Cell protoType;

    [SerializeField]
    private float tileOffset = 0;

    private List<Cell> cells = new List<Cell>();

    public void Start()
    {
        SpawnGrid();
    }

    public void SpawnGrid()
    {
        float xoffset = 0;
        for (int x = 0; x < sizeX; x++)
        {
            float yoffset = 0;
            for (int y = 0; y < sizeY; y++)
            {
                Cell newTile = Instantiate(protoType);
                newTile.transform.SetParent(transform);
                newTile.transform.localPosition = new Vector3(xoffset, 0, yoffset);
                newTile.name = string.Format("Cell {0}x{1}", x, y);

                newTile.X = x;
                newTile.Y = y;

                cells.Add(newTile);

                yoffset += tileOffset;
            }

            xoffset += tileOffset;
        }
    }

    public Cell GetCell(int x, int y)
    {
        if (x > 0 || y > 0)
        {
            return null;
        }
        return transform.GetChild(y + (x * sizeY)).GetComponent<Cell>();
    }

    public bool CellInRange(Cell origin, Cell target, int range, MovementType type)
    {
        switch (type)
        {
            case MovementType.RADIAL:
                return ((Mathf.Sqrt(Mathf.Pow((target.X - origin.X), 2) + Mathf.Pow((target.Y - origin.Y), 2))) <= range);
            case MovementType.STRAIGHT:
                return ((target.X == origin.X && Mathf.Abs(target.Y - origin.Y) <= range) || (target.Y == origin.Y && Mathf.Abs(target.X - origin.X) <= range));
            case MovementType.DIAGONAL:
                return (((Mathf.Abs(target.X - origin.X)) == (Mathf.Abs(target.Y - origin.Y))) && ((Mathf.Sqrt(Mathf.Pow((target.X - origin.X), 2) + Mathf.Pow((target.Y - origin.Y), 2))) <= range));
            case MovementType.DIAGONALEXTRA:
                return (((Mathf.Abs(target.X - origin.X)) == (Mathf.Abs(target.Y - origin.Y))) && ((Mathf.Abs(target.Y - origin.Y)) <= range));
            default:
                return false;
        }
    }

    public enum MovementType
    {
        RADIAL,
        STRAIGHT,
        DIAGONAL,
        DIAGONALEXTRA
    }

    public List<Cell> GetCellsInRange(Cell origin, int range, MovementType type)
    {
        List<Cell> cells = new List<Cell>();

        foreach (Cell cell in this.cells)
        {
            if (CellInRange(origin, cell, range, type))
            {
                cells.Add(cell);
            }
        }

        return cells;
    }

    public void MarkCells(List<Cell> cells)
    {
        foreach (Cell cell in cells)
        {
            cell.MarkCell();
        }
    }

    public void MarkCells(Cell origin, int range, MovementType type)
    {
        MarkCells(GetCellsInRange(origin, range, type));
    }

    public void UnmarkCells(List<Cell> cells)
    {
        foreach (Cell cell in cells)
        {
            cell.UnmarkCell();
        }
    }

    public void UnmarkCells(Cell origin, int range, MovementType type)
    {
        UnmarkCells(GetCellsInRange(origin, range, type));
    }

}
