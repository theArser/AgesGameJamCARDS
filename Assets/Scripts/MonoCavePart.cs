using UnityEngine;

public class MonoCavePart : MonoBehaviour
{
    [SerializeField] private Vector3 p0;
    [SerializeField] private Vector3 p1;
    [SerializeField] private Vector3 p2;
    public MonoCavePart nextPart;

    public Vector3 GetPosition(float t)
    {
        return transform.position + (transform.rotation * (Mathf.Pow(1 - t, 2) * p0 + 2 * (1 - t) * t * p1 + Mathf.Pow(t, 2) * p2));
    }

    public Vector3 GetTangent(float t)
    {
        return transform.rotation * (2 * (1 - t) * (p1 - p0) + 2 * t * (p2 - p1));
    }

    void OnDrawGizmos()
    {
        for (float t = 0.1f; t < 1.01f; t += 0.1f)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(GetPosition(t - 0.1f), GetPosition(t));
        }

        // for (float t = 0.25f; t < 0.9f; t += 0.25f)
        // {
        //     Gizmos.color = Color.blue;
        //     Gizmos.DrawLine(GetPosition(t), GetPosition(t) + GetTangent(t).normalized);
        // }
    }
}
