using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TurnBased {
    public class Player : Entity
    {
        private Enemy enemy;
        
        [SerializeField] private Action chosenAction = null;

        public void Start() {
            enemy = GameObject.FindObjectOfType<Enemy>();
        }

        public void attack() {
            chosenAction = new AttackAction(this, enemy);
        }

        public void defend() {
            chosenAction = new DefendAction(this, enemy);
        }

        public void special() {
            chosenAction = new SpecialAction(this, enemy);
        }

        override public void resetState() {
            base.resetState();
            this.chosenAction = null;
        }

        public Action getChosenAction() {
            return chosenAction;
        }

        //special wastes money
    }
}