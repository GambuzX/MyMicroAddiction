using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {
    public class SteamDiscount : MonoBehaviour
    {

        private TextMesh textMesh;
        
        [SerializeField] int[] validDiscounts = {50, 66, 75, 90, 20};

        // Start is called before the first frame update
        void Start()
        {
            textMesh = GetComponentInChildren<TextMesh>();    
            initDiscountValue();
        }

        void initDiscountValue() {
            int choice = Random.Range(0, validDiscounts.Length);
            textMesh.text = "-" + validDiscounts[choice] + "%";
        }
    }
}
