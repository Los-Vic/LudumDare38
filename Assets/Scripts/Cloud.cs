using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{

	public class Cloud : MonoBehaviour {

		public float speed;
		[HideInInspector]public Vector3 axis;
		[HideInInspector]public AttachedOnFace attachedFace;

		private bool movable;
		private float rainDuration = 3f;
		private float elapse = 0f;
		private bool rain;
		void Start()
		{
			movable = true;
			rain = false;
		}

		void Update()
		{
			if(movable)
				transform.RotateAround (Vector3.zero, axis, speed * Time.deltaTime);
			if (rain)
				elapse += Time.deltaTime;
			if (elapse > rainDuration)
				Destroy (gameObject);
		}
		void OnDestroy()
		{
			if (attachedFace != null)
				attachedFace.m_cloud = null;
		}
		public void PourWater()
		{
			movable = false;
			rain = true;				
		}


	}
}
