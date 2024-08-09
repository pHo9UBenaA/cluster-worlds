using UnityEditor;
using UnityEngine;

public class GenerateLightmapUVs : MonoBehaviour
{
    [MenuItem("Tools/Generate Lightmap UVs for All Models")]
    private static void GenerateLightmapUVsForAllModels()
    {
        // フォルダ内の全てのモデルを取得
        string[] guids = AssetDatabase.FindAssets("t:Model", new[] { Constants.ModelFolderPath });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;

            if (modelImporter != null && !modelImporter.generateSecondaryUV)
            {
                // Generate Lightmap UVs を有効にする
                modelImporter.generateSecondaryUV = true;

                // インポート設定を保存
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
            }
        }

        // 変更を保存
        AssetDatabase.SaveAssets();
    }
}
