using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased {
    public class DefendAction : Action
    {

        public DefendAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            msgBox.text = "Player uninstalled LOL";
            self.setDefend(true);
        }

        public override void executeAnimation() {
            Animator anim = self.GetComponent<Animator>();
            anim.SetTrigger(trigger);
        }
    }
}
