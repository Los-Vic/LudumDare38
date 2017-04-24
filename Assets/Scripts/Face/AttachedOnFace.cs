using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public enum OnFaceObject
	{
		Tree,Village,Source,Null
	};
	
	public class AttachedOnFace : MonoBehaviour {

		public OnFaceObject onFaceObj;
		public Transform windStart;
		public Transform windEnd;
		private EditableFace eFace;
	//	private int spawnTimes;
		private Vector3 windDir;
		private GameObject m_cloud;

		void Awake()
		{
			eFace = GetComponent<EditableFace> ();

		}
		void Start()
		{
			if (onFaceObj == OnFaceObject.Tree)
				windDir = windEnd.position - windStart.position;
			else
				windDir = Vector3.zero;
		}

		void Update()
		{
			if (onFaceObj == OnFaceObject.Tree && eFace.faceState == FaceState.Water&&m_cloud == null) {
				SpawnManager.Instance.SpawnCloud (transform.position+eFace.normal*1.5f,eFace.normal,windDir.normalized,out m_cloud);
			}
		}
	}

}