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
            actions.Add(new AttackAction(this, player, "attack"));
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public Action chooseAction() {
            int rand = Random.Range(0, actions.Count);
            return (Action) actions[rand];
        }
    }
}