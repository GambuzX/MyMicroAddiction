using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TurnBased {
    public class Player : Entity
    {
        private Enemy enemy;
        
        [SerializeField] private Action chosenAction = null;
        private Text messageBox;

        public void Start() {
            enemy = GameObject.FindObjectOfType<Enemy>();
            messageBox = GameObject.Find("MessageBox").GetComponent<Text>();
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

        public void run() {
            chosenAction = new RunAction(this, enemy);
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