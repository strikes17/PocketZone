namespace PocketZone.Container
{
    using PocketZone.Util;
    using UnityEngine;

    public class SceneLoaderContainerInit : BaseContainerInit<SceneLoader>
    {
        protected override void InitializeContainer()
        {
            DontDestroyOnLoad(data);
            base.InitializeContainer();
        }
    }

}
