﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare
{

	public class TextShow : MonoBehaviour {

		private Text m_text;
		public Clock clock;

		void Awake()
		{
			m_text = GetComponent<Text> ();
		}
		void Update()
		{
			m_text.text = "Seconds Left: " + (int)clock.duration;
			if(clock.duration <= 0)
				m_text.text = "Game should be over!";
		}
	}
}
