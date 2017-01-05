using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

public class SceneManager
{
    private static SceneManager instance = null;

    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                lock (typeof(SceneManager))
                {
                    if (instance == null)
                    {
                        instance = new SceneManager();
                    }
                }
            }
            return instance;
        }
    }

    private EditorApplication.CallbackFunction updateCallback = null;

    private SceneManager()
    {
        updateCallback = new EditorApplication.CallbackFunction(MaxstAR.ISceneManager.EditorUpdate);
        if (EditorApplication.update == null)
        {
            EditorApplication.update += updateCallback;
        }
        else if (!EditorApplication.update.Equals(updateCallback))
        {
            EditorApplication.update += updateCallback;
        }
    }

	public void SceneUpdated()
	{
		MaxstAR.ISceneManager.SceneUpdated();
	}
}