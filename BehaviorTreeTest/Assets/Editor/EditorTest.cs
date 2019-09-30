using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

public class EditorTest
{
    public static WindowTest _wind;

    [MenuItem("Tools/Window Create")]
    protected static void CreateWindow()
    {
        _wind = EditorWindow.GetWindow<WindowTest>();
        _wind.minSize = Vector2.one * 500;
    }


}

public class WindowTest : EditorWindow
{
    private void OnEnable()
    {
        Debug.LogError("OnEnable");
        EditorTest._wind = this;
        SceneView.duringSceneGui -= OnSceneGUI;
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private void OnSceneGUI(SceneView sceneview)
    {
        Debug.LogError("OnSceneGUI");
    }

    private void OnDestroy()
    {
        SceneView.duringSceneGui -= OnSceneGUI;
    }
}
