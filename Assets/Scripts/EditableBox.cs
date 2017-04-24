using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public enum FaceDir
	{
		Top,Bottom,Front,Back,Right,Left
	};

	[ExecuteInEditMode]
	public class EditableBox : MonoBehaviour {


		public int height;

		void Awake()
		{
			#if UNITY_EDITOR
				ClipFace ();
			#endif
		}

		void Start()
		{
			//ActiveAllFaces ();
		}
		/*void OnDrawGizmos()
		{
			
			switch(height)
			{
			case 1:
				Gizmos.color = Color.blue;
				Gizmos.DrawSphere (transform.position+new Vector3(0,0,0.5f), 0.2f);
				break;
			case 2:
				Gizmos.color = Color.red;
				Gizmos.DrawCube(transform.position+new Vector3(0,0,0.5f), 0.2f*Vector3.one);
				break;
			default:
				break;
			}
		}*/
			
		void ClipFace()
		{
			Collider[] colls = new Collider [3];
			foreach (Transform tf in transform) {
				int i = Physics.OverlapSphereNonAlloc (tf.position, 0.1f,colls);
				if (i > 1) {
					tf.GetComponent<EditableFace> ().notAcitive = true;
				}
				else
					tf.GetComponent<EditableFace> ().notAcitive = false;
			}
		}

		void ActiveAllFaces()
		{
			
			foreach (Transform tf in transform) {
				tf.GetComponent<EditableFace> ().notAcitive = false;
				tf.gameObject.SetActive (true);
			}
		}
	}

}