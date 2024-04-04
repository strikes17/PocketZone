namespace PocketZone.Game
{
    using System;
    using System.Collections;
    using PocketZone.Container;
    using UnityEngine;

    public sealed class ClosestEntitySelectBehaviour : AbstractBehaviour
    {
        [SerializeField]
        private EntitiesContainer _entitiesContainer = default;

        [SerializeField, Min(0f)]
        private float maxDistance = 15f;

        [SerializeField, Min(0f)]
        private float checkInterval = 0.1f;

        public AliveEntity SelectedEntity => _selectedEntity;

        private Coroutine checkCoroutine = default;

        private WaitForSeconds waitForSeconds = default;

        [SerializeField]
        private AliveEntity _selectedEntity = null;

        private void Awake()
        {
            waitForSeconds = new WaitForSeconds(checkInterval);
        }

        private void DeselectEntity()
        {
            _selectedEntity.LifeBehaviour.onLifeEnded -= DeselectEntity;
            _selectedEntity = null;
        }

        private void OnEnable()
        {
            checkCoroutine = StartCoroutine(CheckCoroutine());
            if (_selectedEntity != null)
            {
                _selectedEntity.LifeBehaviour.onLifeEnded += DeselectEntity;
            }
        }

        private void OnDisable()
        {
            if (_selectedEntity != null)
            {
                _selectedEntity.LifeBehaviour.onLifeEnded -= DeselectEntity;
            }
            StopCoroutine(checkCoroutine);
        }

        private IEnumerator CheckCoroutine()
        {
            while (gameObject.activeSelf)
            {
                float minDistance = _selectedEntity == null ?
                maxDistance : Vector2.Distance(_selectedEntity.transform.position, transform.position);

                foreach (AliveEntity entity in _entitiesContainer.DataCollection)
                {
                    if (!entity.IsActiveState)
                        continue;
                    var distance = Vector2.Distance(entity.transform.position, transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        _selectedEntity = entity;
                    }
                }
                yield return waitForSeconds;
            }
        }
    }
}
