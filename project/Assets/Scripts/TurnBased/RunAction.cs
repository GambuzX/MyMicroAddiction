using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased {
    public class RunAction : Action
    {

        private float runChance = 0.3f;
        private float choice = 1;

        public RunAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            if (choice <= runChance) {
                // run
                LevelManager.instance.loadGameRoom();
            }
        }

        public override void executeAnimation() {
            choice = Random.Range(0f, 1f);
            if (choice <= runChance) {
                // run
                msgBox.text = "Player got away!";
            }
            else {
                // do not run
                msgBox.text = "Player failed to get away....";
            }
        }
    }
}
