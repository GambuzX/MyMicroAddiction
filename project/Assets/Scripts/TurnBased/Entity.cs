using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TurnBased {
    public class Entity : MonoBehaviour
    {

        [SerializeField] float health = 100f;
        [SerializeField] float attackDamage = 10f;
        [SerializeField] float specialDamage = 15f;
        private bool defend;

        public void hit(float damage) {
            health -= defend ? damage / 2 : damage;
        }

        public float getHealth() {
            return health;
        }

        public float getAttackDamage() {
            return attackDamage;
        }

        public float getSpecialDamage() {
            return specialDamage;
        }

        public void setDefend(bool b) {
            this.defend = b;
        }

        public bool dead() {
            return health <= 0f;
        }

        virtual public void resetState() {
            defend = false;
        }
    }
}