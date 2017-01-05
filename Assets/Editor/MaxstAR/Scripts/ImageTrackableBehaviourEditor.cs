using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Text;

[CustomEditor(typeof(ImageTrackableBehaviour))]
public class ImageTrackableBehaviourEditor : Editor 
{
    private bool isDirty = false;
	private ImageTrackableBehaviour imageTrackableBehaviour;

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

		imageTrackableBehaviour = (ImageTrackableBehaviour)target;
		imageTrackableBehaviour.UpdateDatabaseInfo();

        isDirty = false;

        int prevDBIdx = imageTrackableBehaviour.DBIndex;
		int newDBIdx = EditorGUILayout.Popup("Database Name", imageTrackableBehaviour.DBIndex,
			imageTrackableBehaviour.DBNameList);
		if (prevDBIdx != newDBIdx)
        {
			isDirty = true;
			imageTrackableBehaviour.SetGroupIndex(newDBIdx);
        }

		int prevTrackableIndex = imageTrackableBehaviour.TrackableIndex;
		int newTrackableIndex = EditorGUILayout.Popup("Trackable Name", imageTrackableBehaviour.TrackableIndex,
			imageTrackableBehaviour.TrackableList);
		if (prevTrackableIndex != newTrackableIndex)
        {
			isDirty = true;
			imageTrackableBehaviour.SetTrackableIndex(newTrackableIndex);
        }

        if (GUI.changed)
        {
            if (imageTrackableBehaviour != null)
            {
                if (isDirty)
                {
                    EditorUtility.SetDirty(imageTrackableBehaviour);
                }
            }

            SceneManager.Instance.SceneUpdated();
        }
	}    
}