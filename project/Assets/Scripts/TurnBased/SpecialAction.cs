using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased {
    public class SpecialAction : Action
    {

        public SpecialAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            msgBox.text = "ORA! ORA! ORA! ORA!";
            opponent.hit(self.getSpecialDamage());
        }

        public override void executeAnimation() {
            Animator anim = self.GetComponent<Animator>();
            anim.SetTrigger(trigger);
        }
    }
}
