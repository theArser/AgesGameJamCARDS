using UnityEngine;
using UnityEngine.Events;

public class CollisionAction : MonoBehaviour
{
    public UnityAction onCollision;

    private void OnTriggerEnter(Collider other)
    {
        onCollision?.Invoke();
    }
}