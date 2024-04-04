namespace PocketZone.Game
{
    using UnityEngine;

    [RequireComponent(typeof(ClosestEntitySelectBehaviour))]
    public sealed class DrawCursorOnClosestSelectedEntity : AbstractBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer = default;

        private ClosestEntitySelectBehaviour entitySelectBehaviour = default;

        private void Awake() => entitySelectBehaviour = GetComponent<ClosestEntitySelectBehaviour>();

        private void Update()
        {
            var target = entitySelectBehaviour.SelectedEntity;
            if (target == null)
                return;
                
            if (target.gameObject.activeSelf)
            {
                spriteRenderer.gameObject.SetActive(true);
                spriteRenderer.transform.position = target.transform.position;
            }
            else
            {
                spriteRenderer.gameObject.SetActive(false);
            }
        }
    }
}
