﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class WaterCounter : MonoBehaviour {

		public int startWater;
		public int maxWater;
		public int leftWater;
		public List<EditableFace> sourceFaces;
		public bool circular;

		public static WaterCounter instance;
		private int totalWater;

		void Awake()
		{
			instance = this;
		}

		void Start()
		{
			totalWater = startWater;
			circular = false;
		}
		void Update()
		{
			if (leftWater < 0)
				LifeFaceHolder.instance.FacesDie ();
		}
		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;

			foreach (EditableFace ef in sourceFaces) {
				Gizmos.DrawRay (ef.transform.position, ef.normal*3f);
			}
		}

		void FixedUpdate()
		{
			foreach (EditableFace ef in sourceFaces) {
				Ray ray = new Ray (ef.transform.position, ef.normal * 3f);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					circular = true;
					Destroy (hit.collider.gameObject);
				}
			}
		}

		public void AddWater(int i)
		{
			totalWater += i;
			if (!circular)
				leftWater--;
		}
		public int GetWaterCount()
		{
			return totalWater;
		}
	}

}