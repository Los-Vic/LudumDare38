using System.Collections;
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
		public bool lockLocalPos;
		public FaceState faceState;

		private Material mat;
		private Vector3 oriPos;
		private ColorCollection cc;
		#endregion

		void Awake()
		{
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
		}
		void Start()
		{
			oriPos = transform.localPosition;
		}
		void Update()
		{				
			mat.color = cc.GetColor(faceState);
		}
		void LateUpdate()
		{
			if (lockLocalPos)
				transform.localPosition = oriPos;
		}
		void OnApplicationQuit()
		{
			#if UNITY_EDITOR
			Destroy (mat);
			#endif
		}

	}

}