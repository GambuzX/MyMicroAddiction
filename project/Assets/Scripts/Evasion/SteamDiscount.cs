using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {
    public class SteamDiscount : MonoBehaviour
    {

        private TextMesh textMesh;
        
        [SerializeField] int[] validDiscounts = {50, 66, 75, 90, 20};

        private int discount = 0;

        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponentInChildren<TextMesh>();    
            initDiscountValue();
        }

        void initDiscountValue() {
            int choice = Random.Range(0, validDiscounts.Length);
            discount = validDiscounts[choice];
            textMesh.text = "-" + discount + "%";
        }

        public int getDiscount() {
            return discount;
        }
    }
}
