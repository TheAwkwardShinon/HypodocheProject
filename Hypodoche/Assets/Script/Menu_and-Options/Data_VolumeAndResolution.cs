using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Hypodoche{

    [CreateAssetMenu(fileName = "newMenuSettingData", menuName = "Data/Menu Data")]

    public class Data_VolumeAndResolution : ScriptableObject
    {
        #region Variables
        public float volume;
        public int resolutionWidth;

        public int resolutionHeight;
        
        #endregion


    }

}
