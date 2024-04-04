namespace PocketZone.Installer
{
    using PocketZone.Game;
    using PocketZone.Gui;
    using UnityEngine;

    public class ShootButtonInstaller : MonoBehaviour
    {
        [SerializeField]
        protected AbstractShootBehaviour shootSource = default;

        [SerializeField]
        protected ShootButton shootButton = default;

        protected virtual void Awake()
        {
            if (shootSource == null)
            {
                Debug.LogError("Shooter GameObject does not have a Shooter Component");
            }
            else
            {
                shootButton.Construct(shootSource);
                Debug.Log("Shooter GameObject Constructed");
            }
        }
    }
}
