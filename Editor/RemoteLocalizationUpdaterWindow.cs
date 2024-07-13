using System.Collections;
using System.Collections.Generic;
using System.IO;
using Services.Runtime.Localization;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class RemoteLocalizationUpdaterWindow : EditorWindow
{
    private const string FrontURLKey = "Locale_FrontURLKey";
    private const string DataURLKey = "Locale_DataURLKey";

    private const int _windowHeight = 155;
    private const int _windowWidht = 400;

    private static string _frontURL;
    private static string _dataURL;   
    
    [MenuItem("Quicorax/RemoteLocalization Window")]
    public static void Init()
    {
        var window = GetWindow(typeof(RemoteLocalizationUpdaterWindow), false, "Remote Localization");
        window.minSize = new Vector2(_windowWidht, _windowHeight);
        window.maxSize = new Vector2(_windowWidht, _windowHeight);

        if (EditorPrefs.HasKey(FrontURLKey))
        {
            _frontURL = EditorPrefs.GetString(FrontURLKey);
        }

        if (EditorPrefs.HasKey(DataURLKey))
        {
            _dataURL = EditorPrefs.GetString(DataURLKey);
        }
            
        window.Show();
    } 
    
    private void OnGUI()
    {
        GUILayout.Label("Remote Localization URL:");
        GUILayout.BeginHorizontal();
        _frontURL = GUILayout.TextField(_frontURL, GUILayout.Height(28), GUILayout.Width(362),
            GUILayout.ExpandWidth(false));
        if (GUILayout.Button(EditorGUIUtility.IconContent("d_UnityEditor.SceneView.png"),
                GUILayout.Height(28), GUILayout.Width(28)))
        {
            System.Diagnostics.Process.Start(_frontURL);
        }

        GUILayout.EndHorizontal();
        GUILayout.Space(10);

        GUILayout.Label("Fetch Data URL:");
        _dataURL = GUILayout.TextField(_dataURL);
        GUILayout.Space(10);

        if (GUILayout.Button("Update Remote Localization", GUILayout.Height(40)))
        {
            SaveURLs();
            FetchData();
        }
    }

    private static void FetchData()
    {
        Debug.Log("UPDATING Remote Localization...");

        var request = new UnityWebRequest(_dataURL, "GET", new DownloadHandlerBuffer(), null);
        request.SendWebRequest().completed += _ =>
        {
            if (request.error != null)
            {
                Debug.Log(request.error);
                return;
            }

            Debug.Log("Remote Localization updated! -> " + request.downloadHandler.text);

            var remoteVariables =
                JsonUtility.FromJson<RemoteLocale>(request.downloadHandler.text);

            File.WriteAllText(Application.dataPath + "/Resources/Localization/LocalizedText.json",
                JsonUtility.ToJson(remoteVariables));
            AssetDatabase.Refresh();
        };
    }
        
    private void SaveURLs()
    {
        EditorPrefs.SetString(FrontURLKey, _frontURL);
        EditorPrefs.SetString(DataURLKey, _dataURL);
    }
}
