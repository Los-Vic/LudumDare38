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
				{
					int id = (int)Mathf.Round(Random.value);
					return colors [id];
				}
			case FaceState.Green:
				{
					int id = 2+(int)Mathf.Round(Random.value);
					return colors [id];
				}
			case FaceState.Water:
				return colors [4];
			case FaceState.Gray:
				return colors [5];
			default:
				return Color.black;
			}
		}

}

}