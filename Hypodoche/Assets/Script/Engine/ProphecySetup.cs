using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Hypodoche
{
    public class ProphecySetup : MonoBehaviour
    {
        #region Variables
        [SerializeField] private CampaignProgression _cp;
        [SerializeField] private Text _bossName;
        [SerializeField] private Text _bossDes;
        [SerializeField] private Text _bossSubt;
        [SerializeField] private Text[] _bossTrapSugg;
        [SerializeField] private Text _bossSugg;
        [SerializeField] private Image _bossImg;
        #endregion

        #region Methods
        private void Start()
        {
            _bossName.text = _cp.GetBossName();
            _bossDes.text = _cp.GetBossDescription();
            _bossSubt.text = _cp.GetBossSubtitle();
            _bossTrapSugg[0].text = _cp.GetBossTrapSuggestions()[0];
            _bossTrapSugg[1].text = _cp.GetBossTrapSuggestions()[1];
            _bossTrapSugg[2].text = _cp.GetBossTrapSuggestions()[2];
            _bossImg.sprite = _cp.GetBossSprite();
            _bossSugg.text = _cp.GetBossSubgestions();
        }
        #endregion
    }
}
