using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {

	public Button shiftButton;

	public RectTransform row1;
	public RectTransform row2;
	public RectTransform row3;
	public RectTransform row4;

	private int containerWidth = 980;

	private string[] lettersRow1 = new string[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n"};
	private string[] lettersRow2 = new string[] {"o","p","q","r","s","t","u","v","w","x","y","z"};
	private string[] lettersRow3 = new string[] {"@", "1","2","3","4","5","6","7","8","9",".","-"};

	public bool shift = false;

	public Letter btnprefab;
	public MainManager mainmanager;
	private Letter btn;
	

	// Use this for initialization
	void Start () {
		DrawKeyboardRow(lettersRow1,row1);
		DrawKeyboardRow(lettersRow2,row2);
		DrawKeyboardRow(lettersRow3,row3);
	}

	public void Shift(){
		shift = !shift;
		if (shift){
			shiftButton.GetComponent<Image>().color = Color.gray;
		} else {
			shiftButton.GetComponent<Image>().color =  Color.white;
		}
	}

	private void DrawKeyboardRow(string[] row, RectTransform container){
		int space = GetButtonOffset(containerWidth,row.Length);
		Debug.Log(space);
		for(int i = 0; i < row.Length; i++){
			string val = row[i];				
			btn = Instantiate(btnprefab) as Letter;
			btn.transform.SetParent(container.transform);
			btn.transform.localPosition = new Vector2(i* 57+(i*space),0);
			btn.GetComponentInParent<Button>().GetComponentInChildren<Text>().text = val;
			btn.GetComponent<Letter>().value = val;
		}
	}

	private int GetButtonOffset(int width, int items){
		int remain = width - 57*items;
		int space = remain / (items-2);
		return space;
	}

	public void Show(){
//		gameObject.transform.Translate(new Vector2(0, -50));
	}
}
