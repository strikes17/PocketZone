namespace PocketZone.Util
{
    using System;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    
    public class SceneLoader : MonoBehaviour
    {
        public readonly string LOADING = "Loading";
        public readonly string GAME = "Game";

        public Action<string> onSceneLoaded = delegate { };

        public virtual void LoadScene(string sceneName)
        {
            if (SceneManager.GetSceneByName(sceneName).isLoaded)
            {
                onSceneLoaded(sceneName);
            }
            else
            {
                AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
                asyncOperation.completed += (asyncop) => OnSceneLoaded(sceneName);
            }
        }

        protected virtual void OnSceneLoaded(string sceneName) => onSceneLoaded(sceneName);

    }
}
