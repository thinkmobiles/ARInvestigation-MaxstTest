using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Text;

[CustomEditor(typeof(ARManager))]
public class ARManagerEditor : Editor
{
	private bool isDirty = false;
	private ARManager arManager;

	public void OnEnable()
	{
		if (PrefabUtility.GetPrefabType(target) == PrefabType.Prefab)
		{
			return;
		}
	}

	public override void OnInspectorGUI()
	{
		if (PrefabUtility.GetPrefabType(target) == PrefabType.Prefab)
		{
			return;
		}

		arManager = (ARManager)target;

		isDirty = false;

		EditorGUILayout.LabelField("App Signature : ");
		string appSignature = arManager.AppSignature;
		arManager.AppSignature = EditorGUILayout.TextArea(appSignature, GUILayout.MaxHeight(40));
		if (string.Equals(appSignature, arManager.AppSignature) == false)
		{
			isDirty = true;
		}

		if (GUI.changed)
		{
			if (isDirty)
			{
				EditorUtility.SetDirty(arManager);
			}

			SceneManager.Instance.SceneUpdated();
		}
	}

	void DrawSeperator()
	{
		EditorGUILayout.Space();
		Texture2D tex = new Texture2D(1, 1);  //1 by 1 Pixel
		GUI.color = Color.gray;
		float y = GUILayoutUtility.GetLastRect().yMax;
		GUI.DrawTexture(new Rect(10.0f, y, Screen.width - 10.0f, 1.0f), tex);
		tex.hideFlags = HideFlags.DontSave;
		GUI.color = Color.white;
		EditorGUILayout.Space();
	}	
}