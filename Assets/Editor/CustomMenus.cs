using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;
using System;
using System.Linq;
using UnityEditor.Build.Reporting;

#if UNITY_5_3
using UnityEditor.SceneManagement;
#endif

public class CustomMenus : MonoBehaviour
{
    static string menu_scene_path = "Assets/Scenes/Menu.unity";
    static string gameplay_scene_path = "Assets/Scenes/Gameplay.unity";
    
    #region Scene Switching 

    #region F1 = Menu 

    [MenuItem("SceneLoader/Menu _F1")]
    private static void PluginScene()
    {
        if (!EditorApplication.isPlaying)
        {
            bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
            if (value)
            {
                EditorApplication.OpenScene(CustomMenus.menu_scene_path);
            }
        }
    }

    #endregion

    #region F3 = GamePlay

    [MenuItem("SceneLoader/GamePlay _F3")]
    private static void MetaverseScene()
    {
        if (!EditorApplication.isPlaying)
        {
            bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
            if (value)
            {
                EditorApplication.OpenScene(CustomMenus.gameplay_scene_path);
            }
        }
    }

    #endregion

    #endregion

    #region Play, Stop And Pause Game

    #region F5 = Play and Stop

    [MenuItem("SceneLoader/PlayStop _F5")]
    private static void PlayStopButton()
    {
        if (!EditorApplication.isPlaying)
        {
            bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
            if (value)
            {
                EditorApplication.OpenScene(CustomMenus.menu_scene_path);
                EditorApplication.ExecuteMenuItem("Edit/Play");
            }
        }

    }

    #endregion

    #region F6 = Pause 

    [MenuItem("SceneLoader/Pause _F6")]
    private static void PauseButton()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExecuteMenuItem("Edit/Pause");
        }
    }

    #endregion

    #endregion

    #region F11 = Clear Console

    [MenuItem("SceneLoader/Clear Console _F11")]
    static void ClearConsole()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            var newflags = StaticEditorFlags.BatchingStatic | StaticEditorFlags.ContributeGI | StaticEditorFlags.NavigationStatic | StaticEditorFlags.OccludeeStatic
                | StaticEditorFlags.OccluderStatic | StaticEditorFlags.OffMeshLinkGeneration | StaticEditorFlags.ReflectionProbeStatic;
            GameObjectUtility.SetStaticEditorFlags(Selection.gameObjects[i], newflags);
            //Selection.gameObjects[i].isStatic = true;
        }
        //   var logEntries = System.Type.GetType("UnityEditorInternal.LogEntries,UnityEditor.dll");
        //   var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        //     clearMethod.Invoke(null, null);
    }

    #endregion

}
