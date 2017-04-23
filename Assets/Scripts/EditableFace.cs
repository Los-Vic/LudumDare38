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

		public FaceState faceState;
		public FaceDir fDir;
		public FaceState preState;

		private Material mat;
		private ColorCollection cc;


		#endregion

		#region UnityEvent
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
			Debug.Log ("mouse event " + gameObject.name);

		}
		#endregion


	}

}