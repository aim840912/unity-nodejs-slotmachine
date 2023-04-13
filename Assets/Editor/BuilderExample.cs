#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEditor;
using UnityEngine;
/*
    嘗試 尚未實裝
*/
public static class BuilderExample
{
    // ! 建立 MenuItem 以及建置專案範例
    [MenuItem("Tools/Build Windows64")]
    static void BuildWindows64()
    {
        var path = Path.GetFullPath(Application.dataPath + "/../Builds/Windows64/" + Application.productName + ".exe");
        BuildProject(path, BuildTarget.StandaloneWindows64);
    }
    [MenuItem("Tools/Build Android")]
    static void BuildAndroid()
    {
        var path = Path.GetFullPath(Application.dataPath + "/../Builds/Android/" + Application.productName + ".apk");
        BuildProject(path, BuildTarget.Android);
    }
    // ! AssetBundle 建置附檔名，可依照團隊喜好調整
    const string AssetBundleExtension = ".assetbundle";
    const string ScenesAssetBundleName = "scenes";
    // ! 取得初始場景的路徑，這邊使用 System.Linq 減少程式複雜度
    static string GetEntryScenePath()
    {
        return EditorBuildSettings.scenes.Where(v => v.enabled).Select(v => v.path).First();
    }
    // ! 取得非初始場景的路徑
    static string[] CollectScenesPathWithoutEntry()
    {
        var paths = new List<string>(EditorBuildSettings.scenes.Where(v => v.enabled).Select(v => v.path));
        paths.RemoveAt(0);
        return paths.ToArray();
    }
    static void BuildProject(string outputPath, BuildTarget target = BuildTarget.Android, BuildOptions buildOptions = BuildOptions.None, BuildAssetBundleOptions buildAssetBundleOptions = BuildAssetBundleOptions.None)
    {
        // Check output path
        // ! 計算輸出路徑，並建置資料夾 (如果不存在的話)
        var bundleOutputDir = Path.GetFullPath(Path.GetDirectoryName(outputPath));
        var playerOutputPath = outputPath;
        if (!Directory.Exists(bundleOutputDir))
        {
            Directory.CreateDirectory(bundleOutputDir);
        }
        // Collect & Build assetbundles
        // ! 計算 AssetBundle Manifest 位置，該 Manifest 會記錄本次所有建置 AssetBundles 的名稱以及之間相依性
        var bundleManifestPath = bundleOutputDir + Path.DirectorySeparatorChar + Path.GetFileName(bundleOutputDir) + ".manifest";
        // ! 設定 AssetBundle 建置資料，在這個範例中，我們僅建立一個 AssetBundle
        var assetBundleBuilds = new AssetBundleBuild[] {
         new AssetBundleBuild {
            assetBundleName = ScenesAssetBundleName + AssetBundleExtension,
            assetNames = CollectScenesPathWithoutEntry(),
         }
      };
        BuildPipeline.BuildAssetBundles(bundleOutputDir, assetBundleBuilds, buildAssetBundleOptions, target);
        // Build Player
        var buildPlayerOptions = new BuildPlayerOptions()
        {
            target = target,
            scenes = new string[] { GetEntryScenePath() },
            options = buildOptions,
            locationPathName = playerOutputPath,
            // ! 設定 AssetBundle Manifest 位置，若 Unity 找不到或是無法載入該 AssetBundle Manifest 路徑，會將所有遊戲資源 (Assets) 包到 APP 中
            assetBundleManifestPath = bundleManifestPath,
        };
        //   var result = BuildPipeline.BuildPlayer(buildPlayerOptions);
        //   if (!string.IsNullOrEmpty(result))
        //   {
        //      throw new System.Exception(result);
        //   }
        // Open folder if not batch mode
        // ! 建置成功開啟建置資料夾，BatchMode 不開啟該資料夾 (e.g. 使用 CLI 介面建置遊戲專案)
        if (!UnityEditorInternal.InternalEditorUtility.inBatchMode)
        {
            System.Diagnostics.Process.Start(bundleOutputDir);
        }
    }
}
#endif