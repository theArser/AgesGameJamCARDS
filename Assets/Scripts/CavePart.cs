using UnityEngine;

public enum Direction
{
    North,
    East,
    South,
    West
}

[System.Serializable]
public class CavePart
{
    public GameObject cavePrefab;
    public Vector3 position;
    public Vector3 entryOffset;
    public Vector3 exitOffset;
    public Direction caveDirection;
}