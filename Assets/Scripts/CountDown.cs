using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountDown : MonoBehaviour {

	private ArrayList items;
	public Image number3;
	public Image number2;
	public Image number1;

	void Awake(){

	}
	// Use this for initialization
	void Start () {
		items = new ArrayList();
		items.Add(number1);
		items.Add (number2);
		items.Add(number3);
	}

	public void ShowItem(int showIndex){
		for(int i = 0; i < items.Count; i ++){
			Image img = (Image) items[i];
			img.enabled = false;
			if(i == showIndex)
				img.enabled = true;
		}
	}

	public void FakeShutter(){
		Image img = (Image) items[2];
		img.enabled = false;
		RectTransform rt = this.GetComponentInParent<RectTransform>();
		Color white = new Color(1,1,1,1);
		rt.GetComponent<Image>().color = white;
		StartCoroutine(BlockWait());
	}

	public IEnumerator BlockWait() {
		yield return new WaitForSeconds(0.2f);
		RectTransform rt = this.GetComponentInParent<RectTransform>();
		Color alpha = new Color(1,1,1,0);
		rt.GetComponent<Image>().color = alpha;

	}
	
}
