using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;

public class MainManager : MonoBehaviour {

	public InputField emailinputfield;
	public InputField messageinputfield;
	public PlayVideoTextureOnUI videoinput;
	public CountDown countdown;
	public RectTransform keyboardpanel;

	public InputField activeinputfield;

	private bool emailactive;

	void Start(){
		emailactive = true;
//		Cursor.visible = false;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(CountDown());
		}
	}

	public void SetEmailActive(){
		Debug.Log("A");
		//SwapActiveInputField(emailinputfield);
	}

	public void SetMessageActive(){
		Debug.Log(messageinputfield.GetType());

		//SwapActiveInputField(messageinputfield);
	}

	public void SwapActiveInputField(InputField i){
//		activeinputfield = i;
		Debug.Log(i.GetType());
	}

	public void pictureOk(){
		Debug.Log ("OK from Manager");
		ShowKeyboardDialog();
	}

	public void  pictureNotOk(){
		Debug.Log("Not okay from mgr");
	}

	public void ShowKeyboardDialog(){
		keyboardpanel.gameObject.SetActive(true);
	}

	private IEnumerator CountDown(){
		WaitForSeconds wait = new WaitForSeconds(1.0f);
		for(int i = 0; i <= 3; i++){
			yield return wait;
			if(i <= 2){
				countdown.ShowItem(i);
			}
			if(i == 3){
				countdown.FakeShutter();
				videoinput.Record();
			}
		}
	}

	public void WriteChar(string character){

		activeinputfield.text += character;
		if(IsValidEmail(activeinputfield.text)){
			Debug.Log ("valid email");
		} else {
			Debug.Log("invalid email");
		}
	}

	public void DelChar(){

		if(activeinputfield.text.Length > 0){
			activeinputfield.text = activeinputfield.text.Remove(activeinputfield.text.Length-1);	
		}
		return;
	}

	public bool IsValidEmail(string emailaddress){
		Regex rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,10})+)$");
		if(rgx.IsMatch(emailaddress)){
			return true;
		} else {
			return false;
		}
	}
}
