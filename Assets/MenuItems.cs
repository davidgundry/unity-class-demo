using UnityEngine;
using UnityEditor;

public static class MenuItems
{
    [MenuItem("PlayerPrefs/Clear")]
    private static void ClearPlayerPrefs() {
        PlayerPrefs.DeleteAll();
    }

    [MenuItem("PlayerPrefs/Clear", true)]
    private static bool ClearPlayerPrefsValidation() {
        return PlayerPrefs.HasKey("HasRun");
    }

    [MenuItem("PlayerPrefs/Set HasRun")]
    private static void CreateFirstRunKey() {
        PlayerPrefs.SetInt("HasRun", 1);
        PlayerPrefs.Save();
    }

    [MenuItem("PlayerPrefs/Set HasRun", true)]
    private static bool CreateFirstRunKeyValidation(){
        return !PlayerPrefs.HasKey("HasRun");
    }

    [MenuItem("GameObject/Create Enemy Unit")]
    private static void CreateEnemyUnit() {
        GameObject prefab = (GameObject) Resources.Load("PathAgent");
        prefab.name = "Path Agent";
        GameObject.Instantiate(prefab);
    }

    [MenuItem("Assets/Create/Create Custom Asset")]
    private static void CreateCustomAsset() {
        ProjectWindowUtil.CreateAssetWithContent("MyCustomAsset.txt", "content of asset");
    }


    [MenuItem("CONTEXT/Rigidbody/Randomise Values")]
    private static void RandomiseValues(MenuCommand command){
        Rigidbody rb = (Rigidbody)command.context;
        // ... 
    }

}
