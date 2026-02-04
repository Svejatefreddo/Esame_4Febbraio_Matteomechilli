using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickManager : MonoBehaviour
{
    
    public float currentPoints;
    public int amount = 1;
    public LayerMask cookieLayerMask;
    public TextMeshProUGUI textMeshProUGUI;
    




    public void Start()
    {
        currentPoints = 0;
        textMeshProUGUI.text = "Cookies  " + currentPoints.ToString();
    }
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero, 100, cookieLayerMask);


            if (hit.collider != null)
            {
                GainPoints();
                   
            }
        }

    }


    public float GetCurrentPoints()
    {
        return currentPoints;
    }


    public void GainPoints()
    {
        currentPoints += amount;
        UiUpdate();
    }

    public void GainPoints(float points)
    {
        currentPoints += points;
        UiUpdate();
    }

    public void SubtractPoints(float points)
    {
        currentPoints -= points;
        UiUpdate();
    }

    public void UiUpdate()
    {
        textMeshProUGUI.text = "Cookies  " + Mathf.FloorToInt(currentPoints).ToString();
    }

}


