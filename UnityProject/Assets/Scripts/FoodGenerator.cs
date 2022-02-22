using UnityEngine;
using UnityEngine.Events;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float minX, maxX, minY, maxY;
    public GenerateFoodEvent onGenerateFood;

    private void Start()
    {
        GenerateFood();
    }

    private void GenerateFood()
    {
        var randomX = Random.Range(minX, maxX);
        var randomY = Random.Range(minY, maxY);
        var food = Instantiate(foodPrefab, new Vector2(randomX, randomY), Quaternion.identity);
        var foodComponent = food.GetComponent<Food>();
        onGenerateFood.Invoke(food);
        foodComponent.onDestroy.AddListener(GenerateFood);
    }
}

[System.Serializable]
public class GenerateFoodEvent : UnityEvent<GameObject> { }
