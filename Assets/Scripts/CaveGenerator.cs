using UnityEngine;
using System.Collections.Generic;

public class CaveGenerator : MonoBehaviour
{
    [SerializeField] int initialCaveParts = 20;
    [SerializeField][Range(0, 1)] float branchChance = 0.2f;
    [SerializeField] GameObject redBallPrefab;
    [SerializeField] List<CavePart> cavePartPalette;

    private void Start()
    {
        GenerateCaves();
    }

    private void GenerateCaves()
    {
        List<Vector3> currentPositions = new List<Vector3> { Vector3.zero };
        List<Quaternion> currentRotations = new List<Quaternion> { Quaternion.identity };
        int branches = 1;
        for (int i = 0; i < initialCaveParts; i++)
        {
            for (int b = branches - 1; b >= 0; b--)
            {
                if (b > 0)
                {
                    bool branchIsColliding = false;
                    for (int ii = b - 1; ii >= 0; ii--)
                    {
                        Vector3 entryOffset = cavePartPalette[0].entryOffset;
                        if (currentPositions[b] - currentRotations[b] * entryOffset == currentPositions[ii] - currentRotations[ii] * entryOffset && b != ii)
                        {
                            Instantiate(redBallPrefab, currentPositions[b], Quaternion.identity);

                            currentPositions.RemoveAt(b);
                            currentRotations.RemoveAt(b);
                            branches--;

                            branchIsColliding = true;
                            break;
                        }
                    }
                    if (branchIsColliding)
                        continue;
                }

                int cavePartIndex = Random.Range(0, cavePartPalette.Count);
                bool createBranch = Random.value < branchChance;
                if (createBranch)
                {
                    branches++;
                    currentPositions.Add(currentPositions[b]);
                    currentRotations.Add(currentRotations[b]);
                    int branchPartIndex = (cavePartIndex + Random.Range(1, cavePartPalette.Count - 1)) % cavePartPalette.Count;

                    CavePart branchPart = cavePartPalette[branchPartIndex];

                    currentPositions[branches - 1] -= currentRotations[branches - 1] * branchPart.entryOffset;
                    GameObject branchInstance = Instantiate(
                        branchPart.cavePrefab,
                        currentPositions[branches - 1],
                        currentRotations[branches - 1]);
                    
                    currentPositions[branches - 1] += (currentRotations[branches - 1] * branchPart.exitOffset);
                    currentRotations[branches - 1] *= Quaternion.Euler(0, GetRotationAngle(branchPart.caveDirection), 0);

                    CavePart selectedPart = cavePartPalette[cavePartIndex];

                    currentPositions[b] -= currentRotations[b] * selectedPart.entryOffset;
                    GameObject caveInstance = Instantiate(
                        selectedPart.cavePrefab,
                        currentPositions[b],
                        currentRotations[b]);
                    currentPositions[b] += (currentRotations[b] * selectedPart.exitOffset);
                    currentRotations[b] *= Quaternion.Euler(0, GetRotationAngle(selectedPart.caveDirection), 0);
                }
                else
                {
                    CavePart selectedPart = cavePartPalette[cavePartIndex];
                    currentPositions[b] -= currentRotations[b] * selectedPart.entryOffset;
                    GameObject caveInstance = Instantiate(
                        selectedPart.cavePrefab,
                        currentPositions[b],
                        currentRotations[b]);

                    currentPositions[b] += (currentRotations[b] * selectedPart.exitOffset);
                    currentRotations[b] *= Quaternion.Euler(0, GetRotationAngle(selectedPart.caveDirection), 0);
                }
            }
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
