using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using UnityEngine.EventSystems;

public class MainManager : MonoBehaviour {

	public InputField emailinputfield;
	public InputField messageinputfield;
	public PlayVideoTextureOnUI videoinput;
	public CountDown countdown;
	public RectTransform keyboardpanel;

	public InputField activeinputfield;


	void Start(){
//		Cursor.visible = false;
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			StartCoroutine(CountDown());
		}
	}

	public void SetActiveInputField(InputField inputfield){
		activeinputfield = inputfield;
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
	}

	public void WriteSpace(){
		activeinputfield.text += " ";
	}

	public void DelChar(){

		if(activeinputfield.text.Length > 0){
			activeinputfield.text = activeinputfield.text.Remove(activeinputfield.text.Length-1);	
		}
		return;
	}

	public void SendEmail(){
		if( IsValidEmail(emailinputfield.text)){
			Debug.Log(emailinputfield.text+ " email correct");
			Debug.Log(messageinputfield.text);
		}
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
