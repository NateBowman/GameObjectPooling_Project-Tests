using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UITextDebug : MonoBehaviour {
    private Text text;

	// Use this for initialization
	void Start () {
	    text = gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    text.text = "Cubes Created (pool size): " + PoolableComponentTest.ObjectCount + "\r\n"
	                + "Cubes Recycled: " + PoolableComponentTest.ObjectRecycleCount + "\r\n"
	                + "Cubes in use: " + PoolableComponentTest.ObjectUseCount;
	}
}
