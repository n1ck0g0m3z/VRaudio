using UnityEngine;
using UnityEditor;
using System.Collections;

public class SearchUI : EditorWindow
{

    /// <summary>
    /// メニューにアイテムを追加し、ウインドウを開く.
    /// </summary>
    [MenuItem("SearchUI/ShowWindow")]
    private static void ShowWindow()
    {
        // ウインドウの取得.
        var window = EditorWindow.GetWindow(typeof(SearchUI));

        // ウインドウの表示.
        window.Show();
    }

    /// ファイルパス.
    /// </summary>
    private string m_filePath = string.Empty;

    
}
