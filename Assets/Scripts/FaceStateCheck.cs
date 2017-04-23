using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare{
public class FaceStateCheck : MonoBehaviour {

		private bool toGreen;
		private EditableFace eFace;

		void Awake()
		{
			eFace = GetComponent<EditableFace> ();
		}

		void Start () {
				toGreen = false;
		}
	

		void Update () {
			if (toGreen&&eFace.faceState!=FaceState.Water) {	
					eFace.faceState = FaceState.Green;
					toGreen = false;
				}
		}
		void LateUpdate()
		{
			FindNearByWater (false);
			eFace.preState = eFace.faceState;
		}
		void OnMouseDown()
		{
			if (Input.GetMouseButton (0)) {
				FindNearByWater (true);
			}
		}

	#region Method

	void FindNearByWater(bool hit)
	{
			if (eFace.faceState == FaceState.Gray| eFace.faceState == FaceState.Water)
			return;

			switch (eFace.fDir) {
			case FaceDir.Top:
			{
					FindOnXZPlane (hit);
					return;
			}
			case FaceDir.Bottom:
			{
					FindOnXZPlane (hit);
					return;
			}
			case FaceDir.Front:
			{
					FindOnXYPlane (hit);
					return;
			}
			case FaceDir.Back:
			{
					FindOnXYPlane (hit);
					return;
			}
			case FaceDir.Left:
			{
					FindOnYZPlane (hit);
					return;
			}
			case FaceDir.Right:
			{
					FindOnYZPlane (hit);
					return;
			}
		default:
			return;
		}
	}
	
		void FindOnXZPlane(bool hit)
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					//Debug.Log (colls [0].GetComponent<EditableFace> ().faceState .ToString());
					if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {

					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (-1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, 1), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, -1), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}	
		}
		void FindOnXYPlane(bool hit)
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					//Debug.Log (colls [0].GetComponent<EditableFace> ().faceState .ToString());
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (-1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, -1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}	
		}
		void FindOnYZPlane(bool hit)
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					//Debug.Log (colls [0].GetComponent<EditableFace> ().faceState .ToString());
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, 1), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, -1), 0.1f, colls) > 0) {
				if (colls [0] != null)
				if (colls [0].GetComponent<EditableFace> ().faceState == FaceState.Water) {
					if (hit)
						eFace.faceState = FaceState.Water;
					else
						toGreen = true;
					//Debug.Log ("Water Nearby!!");
					return;
				}
			}	
		}
		#endregion

}
}