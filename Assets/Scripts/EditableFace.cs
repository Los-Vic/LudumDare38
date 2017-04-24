﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace LudumDare
{

	public enum FaceState
	{
		Brown = 0,
		Yellow = 1,
		Green =2,
		Water = 3,
		Gray = 4
	};


	[ExecuteInEditMode]
	public class EditableFace : MonoBehaviour {
		#region var

		public FaceState faceState;
		public FaceDir fDir;
		public Vector3 normal;
		public FaceState preState;
		public bool notAcitive = false;
		public int height;
		public bool side =false; // 是否是侧面
		[HideInInspector]public FaceNearBy fNearBy;

		private Material mat;
		private ColorCollection cc;


		#endregion

		#region UnityEvent
		void Awake()
		{
			
			if (notAcitive) {
				//Debug.Log (gameObject.name+notAcitive.ToString ());
				gameObject.SetActive (false);
			} 

			height = GetComponentInParent<EditableBox> ().height;
			fNearBy = GetComponent<FaceNearBy> ();
			
			#if UNITY_EDITOR
			mat = GetComponent<Renderer>().sharedMaterial;
			Material m = Instantiate(mat) as Material;
			GetComponent<Renderer>().material = m;
			mat  = m;
			//mat = GetComponent<Renderer> ().material;
			#else

			mat = GetComponent<Renderer> ().material;
			#endif
			if (mat == null)
				Debug.Log ("Cant find attached material");

			cc = FindObjectOfType<ColorCollection> ();
			//SetNormal ();
		}
		void Start()
		{
			preState = faceState;

		}
		void Update()
		{				
			mat.color = cc.GetColor(faceState);
		
		}
		void LateUpdate()
		{
			
		}
		void OnApplicationQuit()
		{
			#if UNITY_EDITOR
			Destroy (mat);
			#endif
		}
		void OnMouseDown()
		{
			//Debug.Log ("mouse event " + gameObject.name);

		}
		#endregion

		#region method

		/// <summary>
		/// Sets the normal.
		/// </summary>
		void SetNormal()
		{
			switch (fDir) {
			case FaceDir.Top:
				{
					normal = Vector3.up;
					return;
				}
			case FaceDir.Bottom:
				{
					normal = Vector3.down;
					return;
				}
			case FaceDir.Front:
				{
					normal = Vector3.back;
					return;
				}
			case FaceDir.Back:
				{
					normal = Vector3.forward;
					return;
				}
			case FaceDir.Left:
				{
					normal = Vector3.left;
					return;
				}
			case FaceDir.Right:
				{
					normal = Vector3.right;
					return;
				}
			default:
				normal = Vector3.zero;
				return;
			}
		}
		#endregion

	}

}