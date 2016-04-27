using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

	public Sprite readySprite;

	private Image image;
	private Sprite initSprite;

	void Start()
	{
		this.image = this.GetComponentInChildren<Image>();
		this.initSprite = this.image.sprite;
	}

	public void SwitchToReady(bool ready)
	{
		if (ready)
		{
			image.sprite = readySprite;
		}
		else
		{
			image.sprite = initSprite;
		}
	}
}
