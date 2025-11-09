using UnityEngine;

public class BlackFog : MonoBehaviour
{
    [SerializeField] private CaveGenerator caveGenerator;
    [SerializeField] private float speed = 1f;
    private float t = 0f;
    private float tTotal = 0f;
    [SerializeField] private MonoCavePart currentCavePart;

    private void OnEnable()
    {
        currentCavePart = caveGenerator.FirstCavePart;
    }
    private void FixedUpdate()
    {
        if (currentCavePart == null) return;

        tTotal += Time.fixedDeltaTime * speed;
        t += Time.fixedDeltaTime * speed;

        while (t > 1f)
        {
            t -= 1f;
            currentCavePart = currentCavePart.nextPart;
        }

        if (currentCavePart != null)
        {
            transform.position = currentCavePart.GetPosition(t);
            transform.rotation = Quaternion.LookRotation(currentCavePart.GetTangent(t).normalized, Vector3.up);
        }
    }
}