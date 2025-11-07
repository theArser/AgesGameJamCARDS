using UnityEngine;
using System.Collections.Generic;

public class CaveGenerator : MonoBehaviour
{
    [SerializeField] int initialCaveParts = 20;
    [SerializeField] List<CavePart> cavePartPalette;

    private void Start()
    {
        GenerateCaves();
    }

    private void GenerateCaves()
    {
        Vector3 currentPosition = Vector3.zero;
        Quaternion currentRotation = Quaternion.identity;
        for (int i = 0; i < initialCaveParts; i++)
        {
            CavePart selectedPart = cavePartPalette[Random.Range(0, cavePartPalette.Count)];
            currentPosition -= currentRotation * selectedPart.entryOffset;
            GameObject caveInstance = Instantiate(
                selectedPart.cavePrefab,
                currentPosition,
                currentRotation);

            currentPosition += (currentRotation * selectedPart.exitOffset);
            currentRotation *= Quaternion.Euler(0, GetRotationAngle(selectedPart.caveDirection), 0);
        }
        
    }

    private float GetRotationAngle(Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                return 0f;
            case Direction.East:
                return 90f;
            case Direction.South:
                return 180f;
            case Direction.West:
                return 270f;
            default:
                return 0f;
        }
    }
}
