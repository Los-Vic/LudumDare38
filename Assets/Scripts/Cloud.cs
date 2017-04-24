using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public enum RotateAxis
	{
		X,Y,Z
	};

	public class Cloud : MonoBehaviour {

		public RotateAxis axis;
		public float speed;

		private RotateAxis preAxis;
		private Vector3 axisVector;

		void Start()
		{
			preAxis = axis;
			axisVector = ChangeAxis ();
		}

		void Update()
		{
			if (preAxis != axis) {
				axisVector = ChangeAxis ();
				preAxis = axis;
			}

			transform.RotateAround (Vector3.zero, axisVector, speed * Time.deltaTime);
				
		}

		Vector3 ChangeAxis()
		{
			switch (axis) {
			case RotateAxis.X:
				return Vector3.right;
			case RotateAxis.Y:
				return Vector3.up;
			case RotateAxis.Z:
				return Vector3.forward;
			default:
				return Vector3.zero;
			}
		}

	}
}
