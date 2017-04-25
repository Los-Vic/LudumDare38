using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace LudumDare
{
//	[ExecuteInEditMode]
	public class CamMove : MonoBehaviour {

		public Transform target;
		public float rotateVelocity;

		private Camera cam;
		private Vector2 lastPoint = Vector2.zero;

		//#region Unity
		void Awake()
		{
			cam = GetComponent<Camera> ();
		}

		void Start()
		{
		//	transform.LookAt (target);//相机始终指向魔方中
		}

		/*
		void Update()
		{
			transform.RotateAround (Vector3.zero, Vector3.up, rotateVelocity  * Time.deltaTime);
		}*/

		void Update()
		{
			//transform.RotateAround (Vector3.zero, Vector3.up, rotateVelocity * Time.deltaTime);
		//	transform.LookAt (target);//相机始终指向魔方中
			if (Input.GetMouseButtonDown (1))
				lastPoint = Input.mousePosition;

			if (Input.GetMouseButton (1)) {
				Vector2 delta = new Vector2 (Input.mousePosition.x, Input.mousePosition.y) - lastPoint;
				Vector3 n = CalculateRotateAxis (delta);
			//	Debug.Log ("delta = "+delta.ToString());
				transform.RotateAround (Vector3.zero, n.normalized, 1000*rotateVelocity* n.magnitude * Time.deltaTime);
				lastPoint = Input.mousePosition;
			}

			//滚轮滑动
			if (Input.GetAxis ("Mouse ScrollWheel")<0) {
				if (cam.fieldOfView < 80)
					cam.fieldOfView += 2;
			}

			if (Input.GetAxis ("Mouse ScrollWheel")>0) {
				if (cam.fieldOfView >30)
					cam.fieldOfView -= 2;
			}
				
		}

		/// <summary>
		/// 根据摄像机轴线和鼠标移动矢量计算旋转轴和旋转量
		/// </summary>
		private Vector3 CalculateRotateAxis(Vector2 dragVector)
		{
			
			Vector3 a = transform.forward;
			Vector3 b = cam.ScreenToWorldPoint (new Vector3 (dragVector.x, dragVector.y, cam.nearClipPlane))
			            - cam.ScreenToWorldPoint (new Vector3 (0, 0, cam.nearClipPlane));


			Vector3 n = Vector3.Cross (a, b);
		//	Debug.Log (n.ToString());
			return n;
		}
	}
}