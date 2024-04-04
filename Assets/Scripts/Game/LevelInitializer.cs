namespace PocketZone.Game
{
    using System.Collections.Generic;
    using System.Linq;
    using Unity.VisualScripting;
    using UnityEngine;

    public class LevelInitializer : MonoBehaviour
    {
        [SerializeField]
        protected EntitySpawner entitySpawner = default;

        [SerializeField]
        protected LoadGameStateController loadGameStateController = default;

        [SerializeField]
        protected Vector2 minSpawnPosition = default;

        [SerializeField]
        protected Vector2 maxSpawnPosition = default;

        private void Awake()
        {
            NewGame();
        }

        /// <summary>
        /// WIP
        /// </summary>
        public void LoadGame()
        {
            loadGameStateController.LoadGame();
        }

        public void NewGame()
        {
            for (int i = 0; i < 3; i++)
            {
                var randomPos = new Vector2(Random.Range(minSpawnPosition.x, maxSpawnPosition.x), Random.Range(minSpawnPosition.y, maxSpawnPosition.y));
                entitySpawner.SpawnEntity(randomPos);
            }
        }

        private void OnApplicationQuit() => loadGameStateController.SaveGame();
    }
}
