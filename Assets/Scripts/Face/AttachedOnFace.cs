using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public enum OnFaceObject
	{
		Tree,Village,Source,Null,Grass,Sand,Flower,Water,Stone
	};
	
	public class AttachedOnFace : MonoBehaviour {

		public OnFaceObject onFaceObj;
		public Transform windStart;
		public Transform windEnd;
		private EditableFace eFace;
	//	private int spawnTimes;
		private Vector3 windDir;
		[HideInInspector]public GameObject m_cloud;
		private GameObject attachedObj;


		void Awake()
		{
			eFace = GetComponent<EditableFace> ();
			m_cloud = null;

		}
		void Start()
		{
			ChangeAttachedObj ();
			
			if (onFaceObj == OnFaceObject.Tree)
				windDir = windEnd.position - windStart.position;
			else
				windDir = Vector3.zero;
		}

		void Update()
		{
			if (onFaceObj == OnFaceObject.Tree&&m_cloud == null&& CheckNearByWater ()) {
					SpawnManager.instance.SpawnCloud (transform.position + eFace.normal * 3f, eFace.normal, windDir.normalized, this, out m_cloud);
					m_cloud.SetActive (true);

			}
			if (eFace.preState != eFace.faceState) {
				ChangeAttachedObj ();
			}
		}
			
		void SetUpObjDir()
		{
			if(onFaceObj == OnFaceObject.Flower)
				attachedObj.transform.position = transform.position+ eFace.normal*0.2f;
			else
				attachedObj.transform.position = transform.position - eFace.normal*0.98f;
			
			switch (eFace.fDir) {
			case FaceDir.Top:
				{
					break;
				}
			case FaceDir.Bottom:
				{
					attachedObj.transform.rotation = Quaternion.Euler (0, 0, 180);
					break;
				}
			case FaceDir.Back:
				{
					attachedObj.transform.rotation = Quaternion.Euler (90, 0, 0);
					break;
				}
			case FaceDir.Front:
				{
					attachedObj.transform.rotation = Quaternion.Euler (-90, 0, 0);
					break;
				}
			case FaceDir.Right:
				{
					attachedObj.transform.rotation = Quaternion.Euler (0, 0,-90);
					break;
				}
			case FaceDir.Left:
				{
					attachedObj.transform.rotation = Quaternion.Euler (0, 0, 90);
					break;
				}
			default:
				break;
			}

		}
		public void ChangeAttachedObj()
		{
			switch (eFace.faceState) {
			case FaceState.Brown:
				{
					onFaceObj = OnFaceObject.Sand;
					break;
				}
			case FaceState.Green:
				{
					onFaceObj = OnFaceObject.Grass;
					break;
				}
			case FaceState.Water:
				{
					onFaceObj = OnFaceObject.Water;
					break;
				}
			case FaceState.Gray:
				{
					onFaceObj = OnFaceObject.Stone;
					break;
				}
			case FaceState.Flower:
				{
					onFaceObj = OnFaceObject.Flower;
					break;	
				}
			default:
				break;
			}

			if (onFaceObj != OnFaceObject.Flower) {//Debug.Log ("called");
				if (attachedObj != null)
					Destroy (attachedObj);
			}
			
			GameObject obj = ModelCollection.instance.GetModel (onFaceObj);

			if (obj != null) {
			//	Debug.Log ("create obj");
				attachedObj = Instantiate (obj, Vector3.zero, Quaternion.identity);
				attachedObj.transform.SetParent (transform);
				SetUpObjDir ();
			}
		}

		bool CheckNearByWater()
		{
			foreach (EditableFace ef in eFace.fNearBy.midLevel) {
				if (ef.preState == FaceState.Water) {
					return true;
				}
			}	
			return false;
						
		}
	}

}