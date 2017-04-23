using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare{
public class MyDebug : MonoBehaviour {


	void Start()
	{
			Debug.Log ("local pos "+ transform.localPosition.ToString());

			Debug.Log ("world pos "+ transform.position.ToString());
	}
	// Update is called once per frame
	void Update () {


	}
}
}
