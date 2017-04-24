using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace LudumDare
{
	public class Restart : MonoBehaviour {

		public void RestartLevel()
		{
			SceneManager.LoadScene(0);
		}
	}
}
