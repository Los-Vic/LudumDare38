using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class WaterCounter : MonoBehaviour {

		public int startWater;
		//public int maxWater;
		public List<EditableFace> sourceFaces;
		public bool circular;

		public static WaterCounter instance;
		private int totalWater;
		//private ParticleSystem ps;
		private Collider lastHit;
		private bool blossom;

		void Awake()
		{
			instance = this;
		//	ps = GetComponentInChildren<ParticleSystem> ();
		}

		void Start()
		{
			totalWater = startWater;
			circular = false;
			blossom = false;
		}
		void Update()
		{
			if (Clock.instance.duration < 0)
				LifeFaceHolder.instance.FacesDie ();
			/*if (circular && !blossom) {
				blossom = true;
				LifeFaceHolder.instance.FacesFlower ();
			}*/
		}
		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			foreach (EditableFace ef in sourceFaces) {
				Gizmos.DrawRay (ef.transform.position, ef.normal*6f);
			}
		}

		void FixedUpdate()
		{
			foreach (EditableFace ef in sourceFaces) {
				Ray ray = new Ray (ef.transform.position, ef.normal * 6f);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					if (lastHit == null || lastHit.GetInstanceID() != hit.collider.GetInstanceID()) {
						circular = true;
						//ps.Play ();
						hit.collider.GetComponent<Animation>().Play();
						hit.collider.GetComponent<Cloud> ().PourWater ();
						lastHit = hit.collider;
					}
				}
			}
		}

		public void AddWater(int i)
		{
			totalWater += i;
		}
		public int GetWaterCount()
		{
			return totalWater;
		}
	}

}