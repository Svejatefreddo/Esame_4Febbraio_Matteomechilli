
    using UnityEngine;
using UnityEngine.UIElements;

public class PointsGenerator : MonoBehaviour
{
    public float  profit = 0.4f;
    public float interval = 2.0f;
    private float timer = 0f;
    public float pointsXSecond = 0f;
     ClickManager clickManager;
    public float passivePointsAmount = 0f;

    public void Awake()
    {
        clickManager = FindFirstObjectByType<ClickManager>();
    }
    private void Start()
    {
        timer = 0f;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= interval)
        {

            PassivePoints();
            timer = 0f;
        }
    }

    public void PassivePoints()
    {
        passivePointsAmount = pointsXSecond * profit;
        float currentPoints = clickManager.GetCurrentPoints();
        clickManager.GainPoints(profit);

    }
}

