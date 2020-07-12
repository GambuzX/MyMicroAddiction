using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TurnBased {
    public abstract class RitoAction : Action
    {

        protected string[] quotes = {
            "HAVE YOU SEEN STAR GUARDIANS ?!?",
            "ISN'T TEEMO CUTE?? BUY THIS SKIN",
            "Client crashed",
            "Player banned for toxicity",
            "Blindpicked Teemo"
        };

        public RitoAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void executeAnimation() {
            Animator anim = self.GetComponent<Animator>();
            anim.SetTrigger(trigger);
        }
    }
}
