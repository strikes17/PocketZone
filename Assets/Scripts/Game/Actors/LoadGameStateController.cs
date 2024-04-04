namespace PocketZone.Game
{
    using System.Collections.Generic;
    using System.IO;
    using PocketZone.Container;
    using UnityEngine;

    /// <summary>
    /// WIP
    /// </summary>
    public class LoadGameStateController : MonoBehaviour
    {
        [SerializeField]
        protected EntitiesContainer entitiesContainer = default;

        [SerializeField]
        protected EntityDataContainer entityDataContainer = default;

        [SerializeField]
        protected EntitySpawner entitySpawner = default;

        public void SaveGame()
        {
            List<SerializableAliveEntity> AliveEntities = new List<SerializableAliveEntity>();
            foreach (AbstractEntityBehaviour entity in entitiesContainer.DataCollection)
            {
                if (entity is AliveEntity)
                {
                    AliveEntities.Add(new SerializableAliveEntity()
                    {
                        Health = entity.GetComponent<LifeBehaviour>().HealthValue,
                        Position = entity.transform.position,
                        IsAlive = entity.IsActiveState,
                        DataName = entity.EntityData.name
                    });
                }
            }

            SaveFile saveFile = new SaveFile()
            {
                Entities = AliveEntities
            };
            var path = $"{Application.persistentDataPath}/Saves";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, "save.json");
            File.WriteAllText(filePath, JsonUtility.ToJson(saveFile, true));
        }

        public void LoadGame()
        {
            var path = $"{Application.persistentDataPath}/Saves";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var filePath = Path.Combine(path, "save.json");
            var text = File.ReadAllText(filePath);
            var saveFile = JsonUtility.FromJson<SaveFile>(text);

            var dictionary = entityDataContainer.DataCollection as Dictionary<string, EntityData>;
            foreach (var savedEntity in saveFile.Entities)
            {
                if(!savedEntity.IsAlive)
                {
                    continue;
                }
                var entity = entitySpawner.SpawnEntity(savedEntity.Position);
                entity.LifeBehaviour.HealthValue = savedEntity.Health;
            }
        }
    }
}
