using System.Collections;
using System.Collections.Generic;
using Firebase;
using Firebase.Unity.Editor;
using UnityEngine;

public class FirebaseSetup : MonoBehaviour {

	void Start () {
		FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://tkjam2019.firebaseio.com/");
	}
}