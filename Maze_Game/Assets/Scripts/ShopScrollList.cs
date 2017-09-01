using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Obstacle
{
    public string obstacleName;
    public Sprite icon;
    public float price = 1f;
}

public class ShopScrollList : MonoBehaviour
{
    public List<Obstacle> obstacleList;
    public Transform contentPanel;
    public Text myPointsDisplay;
    public SimpleObjectPool buttonObjectPool;
    public float points = 100f;

	// Use this for initialization
	void Start ()
    {
        RefreshDisplay();
	}
	
    public void RefreshDisplay()
    {
        myPointsDisplay.text = "Gold: " + points.ToString();
        //RemoveButtons();
        AddButtons();
    }

	private void AddButtons()
    {
        for (int i = 0; i < obstacleList.Count; i++)
        {
            Obstacle obstacle = obstacleList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(obstacle, this);
        }
    }
}
