using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare
{
	public class Clock : MonoBehaviour {

		public float duration;
		public static Clock instance;
		public bool stop;

		private float elapse;

		void Awake()
		{
			instance = this;
		}
		void Start()
		{
			elapse = 1;
			stop = false;
		}
		void Update()
		{
			if (!stop) {
				elapse = 1 + 4 * WaterCounter.instance.GetWaterCount () / WaterCounter.instance.maxWater;
				if (duration > 0)
					duration -= Time.deltaTime * elapse;
			}
			if (WaterCounter.instance.circular)
				stop = true;
		}

	}
}