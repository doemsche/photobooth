using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {

	private string[] letters = new string[] {"a", "b", "c","d","e","f"};
	public Letter btnprefab;

	private Letter btn;
	

	// Use this for initialization
	void Start () {
		for(int i = 0; i < letters.Length; i++){
			string val = letters[i];
			btn = Instantiate(btnprefab) as Letter;
			btn.transform.parent = gameObject.transform;
			btn.transform.localPosition = new Vector2(i* 90+10,100);
			btn.GetComponentInParent<Button>().GetComponentInChildren<Text>().text = val;
			btn.GetComponent<Letter>().value = val;
		}
	}

	public void Show(){
//		gameObject.transform.Translate(new Vector2(0, -50));
	}
}
