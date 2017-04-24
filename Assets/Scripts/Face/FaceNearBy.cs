using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	/// <summary>
	/// 存储与该相关的面
	/// </summary>
	public class FaceNearBy : MonoBehaviour {

		public List<EditableFace> midLevel; //周围4个面
		public List<EditableFace> highLevel;//对应法线上方4个面
		public List<EditableFace> lowLevel;//对应法线下方4个面

		private EditableFace eFace;


		void Awake()
		{
			eFace = GetComponent<EditableFace> ();
			midLevel = new List<EditableFace> ();
			highLevel = new List<EditableFace> ();
			lowLevel = new List<EditableFace> ();
		}
		void Start()
		{
			midLevel.Clear ();
			highLevel.Clear ();
			lowLevel.Clear ();

			GetMidLevel ();
			GetHighLevel ();
			GetLowLevel ();

			//是否是侧面
			foreach (EditableFace ef in highLevel) {
				if (eFace.height > ef.height)
					eFace.side = true;
			}
			//Debug.Log ("Mid" + midLevel.Count + "High" + highLevel.Count + "Low" + lowLevel.Count);
		}


		#region method
		// 同一个面（四方）
		void GetMidLevel()
		{

			switch (eFace.fDir) {
			case FaceDir.Top:
				{
					FindOnXZPlane ();
					return;
				}
			case FaceDir.Bottom:
				{
					FindOnXZPlane ();
					return;
				}
			case FaceDir.Front:
				{
					FindOnXYPlane ();
					return;
				}
			case FaceDir.Back:
				{
					FindOnXYPlane ();
					return;
				}
			case FaceDir.Left:
				{
					FindOnYZPlane ();
					return;
				}
			case FaceDir.Right:
				{
					FindOnYZPlane ();
					return;
				}
			default:
				return;
			}
		}

		void FindOnXZPlane()
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (-1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, 1), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, -1), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}	
		}

		void FindOnXYPlane()
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (-1, 0, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, -1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}	
		}

		void FindOnYZPlane()
		{
			Collider[] colls = new Collider[1];
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, -1, 0), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, 1), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}
			if (Physics.OverlapSphereNonAlloc (transform.position + new Vector3 (0, 0, -1), 0.1f, colls) > 0) {
				if (colls [0] != null)
					midLevel.Add (colls [0].GetComponent<EditableFace>());
			}	
		}

		//沿着法线方向
		void GetHighLevel()
		{ 
			Collider[] colls;
			switch (eFace.fDir) {
			case FaceDir.Top:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.up * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.up * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Bottom:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.down * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.down * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Front:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.back * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.back * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Back:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.forward * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.forward * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Left:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.left * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.left * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Right:
				{
					colls = Physics.OverlapBox (transform.position + Vector3.right * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position + Vector3.right * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						highLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			default:
				return;
			}
		}

		//逆着法线方向
		void GetLowLevel()
		{ 
			Collider[] colls;
			switch (eFace.fDir) {
			case FaceDir.Top:
				{
					colls = Physics.OverlapBox (transform.position - Vector3.up * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.up * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
							lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Bottom:
				{
					 colls = Physics.OverlapBox (transform.position - Vector3.down * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.down * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
							lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Front:
				{
					colls = Physics.OverlapBox (transform.position - Vector3.back * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.back * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Back:
				{
					colls = Physics.OverlapBox (transform.position - Vector3.forward * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.forward * 0.5f, new Vector3 (0.6f, 0.1f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Left:
				{
					 colls = Physics.OverlapBox (transform.position - Vector3.left * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.left * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			case FaceDir.Right:
				{
					colls = Physics.OverlapBox (transform.position - Vector3.right * 0.5f, new Vector3 (0.1f, 0.6f, 0.1f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					colls = Physics.OverlapBox (transform.position - Vector3.right * 0.5f, new Vector3 (0.1f, 0.1f, 0.6f));
					foreach (Collider col in colls) {
						lowLevel.Add (col.GetComponent<EditableFace>());
					}
					return;
				}
			default:
				return;
			}
		}
		#endregion
	}	

}