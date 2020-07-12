using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased {
    public class Enemy : Entity
    {

        private Player player;

        private ArrayList actions = new ArrayList();

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            actions.Add(new EzrealUltAction(this, player, "ezult"));
            actions.Add(new ShroomAction(this, player, "shroom"));
            actions.Add(new RitoGuard(this, player, "ritoguard"));
        }

        public Action chooseAction() {
            int rand = Random.Range(0, actions.Count);
            return (Action) actions[rand];
        }
    }
}