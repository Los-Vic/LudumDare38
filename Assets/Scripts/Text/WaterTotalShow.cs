using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace LudumDare{
	public class WaterTotalShow : MonoBehaviour {

		private Text m_text;

		void Awake()
		{
			m_text = GetComponent<Text> ();
		}
		void Update()
		{
			m_text.text = "Water Count: " + WaterCounter.instance.GetWaterCount ();
		}
	
	}

}