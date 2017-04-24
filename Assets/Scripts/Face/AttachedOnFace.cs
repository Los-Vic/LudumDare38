using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public enum OnFaceObject
	{
		Tree,Village,Null
	};
	
	public class AttachedOnFace : MonoBehaviour {

		public OnFaceObject onFaceObj;
		private EditableFace eFace;
		private int spawnTimes;

		void Awake()
		{
			eFace = GetComponent<EditableFace> ();

		}
		void Start()
		{
			spawnTimes = 1;
		}

		void Update()
		{
			if (spawnTimes>0&&onFaceObj == OnFaceObject.Tree && eFace.faceState == FaceState.Water) {
				SpawnManager.Instance.SpawnCloud (transform.position+eFace.normal*1.5f,RotateAxis.Z);
				spawnTimes--;
			}
		}
	}

}