using UnityEngine;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Text text;

    private Transform goal;
    private int count;

    private void Start()
    {
        count = 0;
    }

    private void FixedUpdate()
    {
        Move(goal.position - transform.position);
    }

    private void Move(Vector2 direction)
    {
        direction = direction.normalized;
        Vector2 position = transform.position;
        position += direction * (speed * Time.fixedDeltaTime);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var foodComponent = collision.GetComponent<Food>();
        if (foodComponent)
        {
            Eat(foodComponent);
            Debug.Log("Hmm... Delicious :)");
            count++;
            text.text = $"Néctares coletados: {count}";
        }
    }

    private void Eat(Food f)
    {
        f.Eat();
    }

    public void OnPerceiveFood(GameObject food)
    {
        goal = food.transform;
    }
}
