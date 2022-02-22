using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    public UnityEvent onDestroy;

    private void OnDestroy()
    {
        onDestroy.Invoke();
    }
}
