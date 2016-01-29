using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;


public class PlayVideoTextureOnUI : MonoBehaviour {

	public Camera camera;	
	public RawImage videoInput;

	private WebCamTexture webcamTexture;

	public RectTransform staticPicture;

	public InputField emailAddressInput;

	private int resWidth = 3840;
	private int resHeight = 2160;
	public Color32[] data;

	Texture2D snap;
	RenderTexture rendertexture;

	// Use this for initialization
	void Start () {
		webcamTexture = new WebCamTexture();
		videoInput.texture = webcamTexture;
		videoInput.material.mainTexture = webcamTexture;
		Debug.Log (webcamTexture.deviceName);
		webcamTexture.Play ();
	}

	public void Pause(){
		webcamTexture.Pause();
	}

	public void Play(){
		webcamTexture.Play();
	}

	public void Stop(){
		webcamTexture.Stop();
	}

	public void Record(){
		Debug.Log ("REcord action");
		snap = new Texture2D(webcamTexture.width, webcamTexture.height);
		snap.SetPixels(webcamTexture.GetPixels());
		snap.Apply();

		staticPicture.GetComponent<RawImage>().texture = snap;

		staticPicture.transform.Translate(0,1154,0);
		//	System.IO.File.WriteAllBytes("./" + Time.deltaTime.ToString() + ".png", snap.EncodeToPNG());


//		data = new Color32[webcamTexture.width * webcamTexture.height];
//		Debug.Log (videoInput.GetType ());
//		webcamTexture.GetPixels32(data);
		//StartCoroutine(CapturePhoto());
	}

	public void SavePicture(){
		string name = emailAddressInput.text;
		System.IO.File.WriteAllBytes("../service_nodemail/photomail/" + name + ".png", snap.EncodeToPNG());
	}


	public IEnumerator CapturePhoto(){
		yield return new WaitForEndOfFrame();
		rendertexture = new RenderTexture(webcamTexture.width, webcamTexture.height,16); 
		//rendertexture = webcamTexture;
		camera.targetTexture = rendertexture;
		Texture2D screenShot = new Texture2D(webcamTexture.width, webcamTexture.height, 
		                                     TextureFormat.RGB24, false); 
		camera.Render();
//		RenderTexture.active = rendertexture; 
		screenShot.ReadPixels ( new Rect(0, 0, webcamTexture.width, webcamTexture.height),0,0 ); 

//		
		Destroy(rendertexture); 
		
		byte[] bytes = screenShot.EncodeToPNG(); 
		string filename =  Time.deltaTime.ToString()+"test_xxx.png";
		System.IO.File.WriteAllBytes(filename, bytes); 
	}


}
