using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour {

	public Sprite readySprite;

	private Image image;
	private Sprite initSprite;

	private void Start()
	{
		this.image = this.GetComponentInChildren<Image>();
		this.initSprite = this.image.sprite;
	}

	public void SwitchToReady(bool ready)
	{
		image.sprite = ready ? readySprite : initSprite;
	}
}
