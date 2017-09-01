using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SampleButton : MonoBehaviour
{

    public Button button;
    public Text nameLabel;
    public Text priceLabel;
    public Image iconImage;

    private Obstacle obstacle;
    private ShopScrollList scrollList;

	// Use this for initialization
	void Start ()
    {
		
	}

    public void Setup(Obstacle currentObstacle, ShopScrollList currentScrollList)
    {
        obstacle = currentObstacle;
        nameLabel.text = obstacle.obstacleName;
        priceLabel.text = obstacle.price.ToString();
        iconImage.sprite = obstacle.icon;
        scrollList = currentScrollList;
    }
}
