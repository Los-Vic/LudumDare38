using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace LudumDare{

	public class ReplaceGameObjectByName : ScriptableWizard {

		public GameObject myBox;
		public Transform mParent;
		public string keyWord;

		[MenuItem("ZYJ/Replace meshes")]
		static  void CreateWindow()
		{
			ScriptableWizard .DisplayWizard<ReplaceGameObjectByName>("Replace the mesh","Replace");
		}

		void OnWizardCreate()
		{
			Transform[] tfs = Selection.GetTransforms (SelectionMode.Deep);
			
			foreach (Transform tf in tfs) {
				if (tf.name.Contains (keyWord)) {
					GameObject go = Instantiate (myBox, tf.localPosition, tf.rotation);
					go.transform.SetParent (mParent);
					DestroyImmediate (tf.gameObject);
				}
			}
		}
	}

}