using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveFileViewer : EditorWindow
{
    string jsonContent;

    [MenuItem("Tools/Save File Viewer")]
    public static void ShowWindow()
    {
        GetWindow<SaveFileViewer>("Save Viewer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Save File Viewer", EditorStyles.boldLabel);

        if (GUILayout.Button("Load Save File"))
        {
            LoadSaveFile();
        }

        GUILayout.Space(10);

        EditorGUILayout.TextArea(jsonContent, GUILayout.Height(300));
    }

    void LoadSaveFile()
    {
        string path = Application.persistentDataPath + "/save.json";

        if (File.Exists(path))
        {
            jsonContent = File.ReadAllText(path);
        } else
        {
            jsonContent = "No save file found.";
        }
    }
}