using UnityEngine;
using UnityEngine.Events;

public class CollisionAction : MonoBehaviour
{
    public UnityEvent onCollision;

    private void OnTriggerEnter(Collider other)
    {
        onCollision?.Invoke();
    }
}