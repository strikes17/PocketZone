using UnityEngine;

namespace PocketZone.Game
{
    public class EntityData : ScriptableObject
    {
        [SerializeField]
        protected string title = string.Empty;

        [SerializeField, Min(0)]
        protected int defaultHealthValue = 0;

        [SerializeField, Min(1)]
        protected int defaultUnarmedDamage = 1;

        [SerializeField, Min(1)]
        protected float unarmedAttackRange = 1f;

        [SerializeField, Min(1)]
        protected float unarmedAttackCooldownTime = 1f;

        public int DefaultUnarmedDamage => defaultUnarmedDamage;

        public string Title => title;

        public int DefaultHealthValue => defaultHealthValue;
        public float UnarmedAttackRange => unarmedAttackRange;
        public float UnarmedAttackCooldownTime => unarmedAttackCooldownTime;
    }
}
