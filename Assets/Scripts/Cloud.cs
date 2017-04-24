using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{

	public class Cloud : MonoBehaviour {

		public float speed;
		public Vector3 axis;

		void Start()
		{
		}

		void Update()
		{
			transform.RotateAround (Vector3.zero, axis, speed * Time.deltaTime);
		}



	}
}
