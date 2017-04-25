using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class LifeFaceHolder : MonoBehaviour {

		public static LifeFaceHolder instance;
		public List<EditableFace> ediFace;

		void Awake()
		{
			instance = this;
		}

		public void FacesDie()
		{
			foreach (EditableFace ef in ediFace)
				ef.faceState = FaceState.Brown;
		}

		public void FacesFlower()
		{
			foreach (EditableFace ef in ediFace) {
				ef.faceState = FaceState.Water;
			}
		}
	}

}