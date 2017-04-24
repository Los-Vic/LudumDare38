using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class SpawnManager : MonoBehaviour {

		public GameObject cloud;
		public static SpawnManager instance;

		void Awake()
		{
			instance = this;
		}

		public void SpawnCloud(Vector3 pos , Vector3 normal,Vector3 wind,AttachedOnFace aof ,out GameObject yun)
		{
			yun = Instantiate (cloud);
			yun.transform.position = pos;
			Vector3 axis = Vector3.Cross (normal, wind).normalized;
			yun.GetComponent<Cloud> ().axis = axis;
			yun.GetComponent<Cloud> ().attachedFace = aof;
		}

	}
}