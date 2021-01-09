using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Hypodoche
{
    public class ChangeResolution : MonoBehaviour
    {

        [SerializeField] Data_VolumeAndResolution _DataCurrentResoluton;


        public void Awake(){
            string[] temp = Screen.currentResolution.ToString().Split(' ');
            Debug.Log("temp[0]: "+temp[0]+ "temp[1]: "+temp[1]);
            _DataCurrentResoluton.resolutionWidth = int.Parse(temp[0]);
            _DataCurrentResoluton.resolutionHeight = int.Parse(temp[2]);
            Screen.SetResolution(_DataCurrentResoluton.resolutionWidth, _DataCurrentResoluton.resolutionHeight, true);
        }


        public void setResolution(int width, int height)
        {
            Screen.SetResolution(width, height, true);
        }

        public void setResolution(int barValue)
        {
            if (barValue == 0)
                setResolution(1920, 1080);
            else if (barValue == 1){
                _DataCurrentResoluton.resolutionWidth = 1280;
                _DataCurrentResoluton.resolutionHeight = 720;
                setResolution(1280, 720);
            }
            else if (barValue == 2){
                _DataCurrentResoluton.resolutionWidth = 1336;
                _DataCurrentResoluton.resolutionHeight = 900;
                setResolution(1336, 900);
            }
            else if (barValue == 3){
                _DataCurrentResoluton.resolutionWidth = 1440;
                _DataCurrentResoluton.resolutionHeight = 900;
                setResolution(1440, 900);
            }
            else if (barValue == 4){
                _DataCurrentResoluton.resolutionWidth = 1536;
                _DataCurrentResoluton.resolutionHeight = 864;
                setResolution(1536, 864);
            }
            else if (barValue == 5){
                _DataCurrentResoluton.resolutionWidth = 1680;
                _DataCurrentResoluton.resolutionHeight = 1050;
                setResolution(1680, 1050);
            }
            else if (barValue == 6){
                _DataCurrentResoluton.resolutionWidth = 1920;
                _DataCurrentResoluton.resolutionHeight = 1200;
                setResolution(1920, 1200);
            }
            else if (barValue == 7){
                _DataCurrentResoluton.resolutionWidth = 1920;
                _DataCurrentResoluton.resolutionHeight = 1080;
                setResolution(1920, 1080);
            }
            else if (barValue == 8){
                _DataCurrentResoluton.resolutionWidth = 2560;
                _DataCurrentResoluton.resolutionHeight = 1440;
                setResolution(2560, 1440);
            }
            else if (barValue == 9){
                _DataCurrentResoluton.resolutionWidth = 3860;
                _DataCurrentResoluton.resolutionHeight = 2160;
                setResolution(3860, 2160);
            }

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
