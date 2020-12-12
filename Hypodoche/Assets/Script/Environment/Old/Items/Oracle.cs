using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class Oracle : MonoBehaviour
    {
        [SerializeField] private List<BossTemperament> _temperaments;
        [SerializeField] private List<TemperamentStats> _stats;
        private int _temp;

        void Start() {
            _temp = PredictTemperament();
            this.transform.GetChild(5).GetComponent<Text>().text = GetDamageQuantity();
            this.transform.GetChild(6).GetComponent<Text>().text = GetDamageSpeed();
            this.transform.GetChild(7).GetComponent<Text>().text = GetDamageReliability();
            this.transform.GetChild(8).GetComponent<Text>().text = GetDamageRange();
            this.transform.GetChild(10).GetComponent<Text>().text = GetTemperamentName();
        }

        private int PredictTemperament() {
            // should be randomic, but we have just one boss now
            return _temperaments[0].temperament;
        }

        private string GetTemperamentName() {
            string name = "Melancholic";
            if (_temp == 1)
            {
                name = "Phlegmatic";
            }

            if (_temp == 2)
            {
                name = "Sanguine";
            }

            if (_temp == 3)
            {
                name = "Choleric";
            }

            return name;
        }

        private string GetDamageQuantity() {
            return _stats[_temp].quantity;
        }

        private string GetDamageSpeed(){
            return _stats[_temp].speed;
        }

        private string GetDamageReliability(){
            return _stats[_temp].reliability;
        }

        private string GetDamageRange() {
            return _stats[_temp].range;
        }

    }
}