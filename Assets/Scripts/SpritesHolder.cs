using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare{

	public enum WaterGridType
	{
		IsolatedSource = 0,
		Line = 1,
		Turn =2,
		LinkedSource = 3,
		Null = 4
	};

	public class SpritesHolder : MonoBehaviour {
	
		public  Sprite[] gridSprites;


	}
}
