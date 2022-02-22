using UnityEngine;

public class FoodGenerator : MonoBehaviour
{
    [SerializeField] private GameObject foodPrefab;
    [SerializeField] private float minX, maxX, minY, maxY;

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
        foodComponent.onDestroy.AddListener(GenerateFood);
    }
}
