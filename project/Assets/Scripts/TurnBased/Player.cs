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

        private Image playerHealth;

        public void Start() {
            enemy = GameObject.FindObjectOfType<Enemy>();
            messageBox = GameObject.Find("MessageBox").GetComponent<Text>();
            playerHealth = GameObject.Find("PlayerHealth").GetComponent<Image>();
        }

        public override void hit(float damage) {
            health -= isDefending ? damage / 2 : damage;
            playerHealth.fillAmount = health / 100f;
        }

        public void attack() {
            chosenAction = new AttackAction(this, enemy, "attack");
        }

        public void defend() {
            chosenAction = new DefendAction(this, enemy, "defend");
        }

        public void special() {
            chosenAction = new SpecialAction(this, enemy, "special");
        }

        public void run() {
            chosenAction = new RunAction(this, enemy, "run");
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