using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Text;

[CustomEditor(typeof(VideoPlayerBehaviour))]
public class VideoPlayerBehaviourEditor : Editor
{
	private bool isDirty = false;
	private VideoPlayerBehaviour videoPlayerBehaviour;

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

		videoPlayerBehaviour = (VideoPlayerBehaviour)target;

		isDirty = false;

		string prevVideoName = videoPlayerBehaviour.VideoName;
		videoPlayerBehaviour.VideoName = EditorGUILayout.TextField("Video Name", videoPlayerBehaviour.VideoName);
		if (string.Equals(prevVideoName, videoPlayerBehaviour.VideoName) == false)
		{
			isDirty = true;
		}

		bool prevContinuousMode = videoPlayerBehaviour.ContinuousPlaying;
		videoPlayerBehaviour.ContinuousPlaying = EditorGUILayout.Toggle("Continuous Playing", videoPlayerBehaviour.ContinuousPlaying);
		if (prevContinuousMode != videoPlayerBehaviour.ContinuousPlaying)
		{
			isDirty = true;
		}

		bool prevAlpha = videoPlayerBehaviour.Transparent;
		videoPlayerBehaviour.Transparent = EditorGUILayout.Toggle("Transparent", videoPlayerBehaviour.Transparent);
		if (prevAlpha != videoPlayerBehaviour.Transparent)
		{
			isDirty = true;
		}

		if (GUI.changed)
		{
			if (videoPlayerBehaviour != null)
			{
				if (isDirty)
				{
					EditorUtility.SetDirty(videoPlayerBehaviour);
				}
			}

			SceneManager.Instance.SceneUpdated();
		}
	}
}