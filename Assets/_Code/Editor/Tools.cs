using UnityEditor;
using UnityEngine;

namespace _Code.Editor
{
    public class Tools
    {
        [MenuItem("Tools/Clear Prefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}