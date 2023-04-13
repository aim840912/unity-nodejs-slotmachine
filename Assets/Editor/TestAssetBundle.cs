using System.IO;
using UnityEditor;


/// <summary>
/// 打包脚本 —— 放在 Editor 文件夹下(规范)
/// </summary>
public class TestAssetBundle
{
    [MenuItem("Test工具/打包AssetsBundle资源")] //菜单栏添加按钮
    static void BuildAllAssetsBundles()
    {
        string folder = "TestAssetBundles";                                                                               //定义文件夹名字
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);                                                  //文件夹不存在，则创建
        BuildPipeline.BuildAssetBundles("TestAssetBundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64); //创建AssetBundle
    }
}