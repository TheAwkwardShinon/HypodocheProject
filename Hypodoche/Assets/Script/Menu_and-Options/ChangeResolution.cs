using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Hypodoche
{
    public class ChangeResolution : MonoBehaviour
    {

        public void setResolution(int width, int height)
        {
            Screen.SetResolution(width, height, true);
        }

        public void setResolution(int barValue)
        {
            if (barValue == 0)
                setResolution(Screen.width, Screen.height);
            else if (barValue == 1)
                setResolution(1280, 720);
            else if (barValue == 2)
                setResolution(1336, 900);
            else if (barValue == 3)
                setResolution(1440, 900);
            else if (barValue == 4)
                setResolution(1536, 864);
            else if (barValue == 5)
                setResolution(1680, 1050);
            else if (barValue == 6)
                setResolution(1920, 1200);
            else if (barValue == 7)
                setResolution(1920, 1080);
            else if (barValue == 8)
                setResolution(2560, 1440);
            else if (barValue == 9)
                setResolution(3860, 2160);

            /*string[] str = resolution.Split('x');
            Debug.Log(str[0]);
            Debug.Log(str[1]);*/
            /*
            int width = int.Parse(str[0]);
            int height = int.Parse(str[1]);

            Screen.SetResolution(width,height, true);*/
        }
    }
}
