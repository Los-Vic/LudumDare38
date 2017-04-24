using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LudumDare{
	public class WaterLeftShow : MonoBehaviour {

		private Text m_text;

		void Awake()
		{
			m_text = GetComponent<Text> ();
		}
		void Update()
		{
			if(!WaterCounter.instance.circular)
				m_text.text = "Left Water: " + WaterCounter.instance.leftWater;
			else
				m_text.text = "Left Water: Water circulation builded!";

			if(WaterCounter.instance.leftWater<1)
				m_text.text = "No water left";
		}
	
	}

}