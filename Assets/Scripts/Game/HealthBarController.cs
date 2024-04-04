namespace PocketZone.Game
{
    using UnityEngine;

    public sealed class HealthBarController : MonoBehaviour
    {
        [SerializeField]
        private Transform _healthBarScaler = default;

        [SerializeField]
        private LifeBehaviour _lifeBehaviour = default;

        private void OnEnable() => _lifeBehaviour.onHealthValueChanged += UpdateBar;

        private void OnDisable() => _lifeBehaviour.onHealthValueChanged -= UpdateBar;

        private void UpdateBar()
        {
            float xScale = (float)_lifeBehaviour.HealthValue / _lifeBehaviour.MaxHealthValue;
            _healthBarScaler.transform.localScale = new Vector3(xScale, 1f, 1f);
        }
    }
}
