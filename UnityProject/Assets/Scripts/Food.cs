using UnityEngine;
using UnityEngine.Events;

public class Food : MonoBehaviour
{
    [SerializeField] private GameObject particleEffect;
    public UnityEvent onDestroy;

    public void Eat()
    {
        Instantiate(particleEffect, transform.position, transform.rotation);
        onDestroy.Invoke();
        Destroy(gameObject);
    }
}
