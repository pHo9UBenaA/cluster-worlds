using UnityEditor;
using UnityEngine;

public class SetLightmapUVsPackMargin
{
    [MenuItem("Tools/Set Lightmap UVs Pack Margin to 40 for All Models")]
    private static void SetPackMarginForAllModels()
    {
        // フォルダ内の全てのモデルを取得
        string[] guids = AssetDatabase.FindAssets("t:Model", new[] { Constants.ModelFolderPath });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            ModelImporter modelImporter = AssetImporter.GetAtPath(assetPath) as ModelImporter;

            if (modelImporter != null && modelImporter.generateSecondaryUV)
            {
                // Pack Marginを40に設定
                modelImporter.secondaryUVPackMargin = 40;

                // インポート設定を保存
                AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);
            }
        }

        // 変更を保存
        AssetDatabase.SaveAssets();
    }
}
