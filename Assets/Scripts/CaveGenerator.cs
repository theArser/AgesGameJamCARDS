using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "CaveGenerator", menuName = "Scriptable Objects/CaveGenerator")]
public class CaveGenerator : ScriptableObject
{
    [SerializeField] List<CavePart> caveParts;
}
