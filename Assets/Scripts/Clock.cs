using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class Clock : MonoBehaviour {

		public float duration;

		void Update()
		{
			if (duration > 0)
				duration -= Time.deltaTime;
		}
	}
}