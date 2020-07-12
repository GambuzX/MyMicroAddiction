using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TurnBased {
    public class RitoGuard : Action
    {

        public RitoGuard(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            msgBox.text = "SERVERS ARE DOWN";
            self.setDefend(true);
        }

        public override void executeAnimation() {
            msgBox.text = "Rito guarded";
        }
    }
}
