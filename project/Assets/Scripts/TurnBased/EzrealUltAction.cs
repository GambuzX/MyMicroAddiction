using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TurnBased {
    public class EzrealUltAction : Action
    {

        public EzrealUltAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            msgBox.text = "HAVE YOU SEEN STAR GUARDIANS ?!?";
            opponent.hit(self.getAttackDamage());
        }

        public override void executeAnimation() {
            Animator anim = self.GetComponent<Animator>();
            anim.SetTrigger(trigger);
        }
    }
}
