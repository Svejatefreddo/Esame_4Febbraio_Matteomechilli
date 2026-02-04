using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public ClickManager clickManager;
    public PointsGenerator pointsGenerator;
    public PointsGenerator handPrefab;

    public List<Transform> transforms = new List<Transform>();

    public int spawnCost = 10;
    public int WinCost = 100;
    public Button UpgradeButton;
    public Button winButton;
    int handIndex = 0;
    public TextMeshProUGUI textUpgradeButton;
    public TextMeshProUGUI textWin;
    public TextMeshProUGUI VITTORIA;
    public TextMeshProUGUI textPerSecond;

    void Start()
    {
        textUpgradeButton.text = "  " + spawnCost.ToString();
        textWin.text = "100 ";
        textPerSecond.text = "PerSecond:  " + pointsGenerator.passivePointsAmount.ToString();
    }


    void Update()
    {
        if(UpgradeButton != null)
        {
            UpgradeButton.interactable = (clickManager.currentPoints >= spawnCost);
        }
        if (winButton != null)
        {
            winButton.interactable = (clickManager.currentPoints >= WinCost);
        }
        textPerSecond.text = "PerSecond:  " + pointsGenerator.passivePointsAmount.ToString();
    }


    public void ButtonUpgrade()
    {
        if(clickManager.currentPoints >= spawnCost)
        {
            clickManager.SubtractPoints(spawnCost);
            spawnCost = Mathf.RoundToInt((float)spawnCost + 1.15f);
            textUpgradeButton.text = "  " + spawnCost.ToString();
            Instantiate(handPrefab, transforms[handIndex].position, Quaternion.identity, transforms[handIndex]);
            handIndex++;
            if(handIndex >= transforms.Count)
            {
                UpgradeButton.gameObject.SetActive(false);
            }
        }
    }
    public void WinButton()
    {
        VITTORIA.text = "VITTORIA!";
    }
}
