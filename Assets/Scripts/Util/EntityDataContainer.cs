namespace PocketZone.Container
{
    using PocketZone.Game;
    using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
    using System.IO;
    using System.Collections.Generic;
#endif

    [CreateAssetMenu(menuName = "PocketZone/New Entity Data Container", fileName = "New Entity Data Container")]
    public class EntityDataContainer : BaseDicionaryContainer<string, EntityData>
    {
        [ContextMenu("Fill In")]
        public void Fill()
        {
#if UNITY_EDITOR
            var directoryInfo = new DirectoryInfo($"{Application.dataPath}/Data/Entities");
            var allFiles = directoryInfo.GetFiles("*.asset", SearchOption.AllDirectories);
            Clear();
            foreach (var file in allFiles)
            {
                
                Debug.Log(file.Name);
                var asset = AssetDatabase.LoadAssetAtPath<EntityData>($"Assets/Data/Entities/{file.Name}");

                AddData(asset.name, asset);
            }
#endif
        }
    }
}
