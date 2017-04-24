using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class SpawnManager : Singleton<SpawnManager> {

		public GameObject cloud;


		public void SpawnCloud(Vector3 pos , RotateAxis axis)
		{
			GameObject yun = Instantiate (cloud);
			yun.transform.position = pos;
			yun.GetComponent<Cloud> ().axis = axis;
		}

	}
}