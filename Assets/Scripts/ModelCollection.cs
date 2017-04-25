using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
public class ModelCollection : MonoBehaviour {

		public GameObject[] objs;
		public static ModelCollection instance;

		void Awake()
		{
			instance = this;
		}

		public GameObject GetModel(OnFaceObject ofb)
		{
			switch (ofb) {
			case OnFaceObject.Sand:
				{
					int id = (int)(Mathf.Floor (Random.value*2));
					return objs [id];
				}
			case OnFaceObject.Grass:
				{
					int id = 3 + (int)Mathf.Round (Random.value);
					return objs [id];
				}
			case OnFaceObject.Water:
				{
					return objs[5];
				}
			case OnFaceObject.Stone:
				{
					int id = 6+(int)Mathf.Round (Random.value);
					return objs [id];
				}
			case OnFaceObject.Flower:
				{
					return objs [8];
				}
			default:
				return null;
			}
		}

	}
}
