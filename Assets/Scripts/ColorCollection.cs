using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare{
public class ColorCollection : MonoBehaviour {

		public Color[] colors;

		public Color GetColor(FaceState fs)
		{
			switch (fs) {
			case FaceState.Brown:
				return colors [0];
			case FaceState.Yellow:
				return colors [1];
			case FaceState.Green:
				return colors [2];
			case FaceState.Water:
				return colors [3];
			case FaceState.Gray:
				return colors [4];
			default:
				return Color.black;
			}
		}

}

}