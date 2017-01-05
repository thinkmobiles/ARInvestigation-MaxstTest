using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;

[CustomEditor(typeof(DatabaseLoader))]
public class DatabaseLoaderEditor : Editor
{
	private DatabaseLoader databaseLoader;

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

		databaseLoader = (DatabaseLoader)target;

		List<string> dbList = MaxstAR.MaxstARUtils.GetDBFileList();
		databaseLoader.ActivateDatabase(dbList);

		EditorUtility.SetDirty(databaseLoader);
	}	
}