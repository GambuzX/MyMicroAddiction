using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TurnBased {
    public class Entity : MonoBehaviour
    {

        [SerializeField] protected float health = 100f;
        [SerializeField] protected float attackDamage = 10f;
        [SerializeField] protected float specialDamage = 15f;
        protected bool isDefending;

        public virtual void hit(float damage) {
            health -= isDefending ? damage / 2 : damage;
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
            this.isDefending = b;
        }

        public bool dead() {
            return health <= 0f;
        }

        virtual public void resetState() {
            isDefending = false;
        }
        
        public void setHealth(float health) {
            this.health = health;
        }
        
        public void setAttackDamage(float d) {
            this.attackDamage = d;
        }
        
        public void setSpecialDamage(float d) {
            this.specialDamage = d;
        }
    }
}