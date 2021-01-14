using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Hypodoche
{
    public class CampaignProgressionManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private CampaignProgression _cp;
        [SerializeField] private Sprite _haljaSprite;
        [SerializeField] private Sprite _liYianSprite;
        [SerializeField] private Sprite _caputmalleiSprite;
        [SerializeField] private SceneDirector _sd;

        [SerializeField] private TrapInventory _ti;
        #endregion

        #region Methods
        public void Setup()
        {
            _cp.LoadBossList();
        }
        public void Advance(bool first)
        {
            string extraction = _cp.ExtractBoss();
            switch(extraction){
                case "Li Yan":
                    Debug.Log("Liyian");
                    SetupLiYian();
                    //EditorUtility.SetDirty(_cp);
                    if(!first){
                        _sd.LoadSceneAtIndex(1);
                        _ti.SetPlayerCoins(_ti.GetPlayerCoins()+9);
                    }
                    break;
                case "Halja":
                    Debug.Log("Halja");
                    SetupHalja();
                    //EditorUtility.SetDirty(_cp);
                    if(!first){
                        _sd.LoadSceneAtIndex(1);
                        _ti.SetPlayerCoins(_ti.GetPlayerCoins()+9);
                    }
                    break;
                case "Caputmallei":
                    Debug.Log("Caput");
                    if(!first){
                        _sd.LoadSceneAtIndex(1);
                        _ti.SetPlayerCoins(_ti.GetPlayerCoins()+9);
                    }
                    SetupCaput();
                    //EditorUtility.SetDirty(_cp);
                    break;
                case null: 
                    Debug.Log("Win");
                    _sd.LoadSceneAtIndex(4);
                    break;
                default:
                    Debug.Log(extraction);
                    _sd.LoadSceneAtIndex(0);
                    break;

            }
        }

        private void SetupLiYian()
        {
            _cp.SetBossName("Li Yan");
            _cp.SetBossSubtitle("- Little Flame -");
            _cp.SetBossDescription("Boss that will run all around the arena without attacking the player. The bombs she loses from her tail are the main threat!");
            _cp.SetBossTrapSuggestions("Traps that can damage the boss even if you aren’t near, she’s pretty fast and difficult to chase.",0);
            _cp.SetBossTrapSuggestions("Anything that can interrupt projectiles: considering the intensity of the bullet hell, this is a given",1);
            _cp.SetBossTrapSuggestions("Traps that interferes with movement: being pretty fast, stunning or slowing her is pretty effective",2);
            _cp.SetBossSuggestions("Bombs on the lower part of the screen will be harder to detect! Always be aware of where Li Yan placed her bombs");
            _cp.SetBossLore("Li Yan character design derives from the Chinese legend of a monster called Nian that would come out to eat villagers and destroy" + 
                            "their houses on each New Year’s Eve. The villagers discovered that burning dry bamboo to produce an explosive sound scared away the monster." +
                            " That’s why she runs around without fighting: she’s too scared by her own tail to do anything!");
            _cp.SetBossSprite(_liYianSprite);
        }

        private void SetupHalja()
        {
            _cp.SetBossName("Halja");
            _cp.SetBossSubtitle("- Merciless Smile of Winter -");
            _cp.SetBossDescription("Boss that will modify your position a lot during the fight, attempting to disorient you and setting you up to multiple threats.");
            _cp.SetBossTrapSuggestions("Stamina regeneration: dodging is one of the main tactics that you have to use in this fight, but it’s pretty stamina consuming.",0);
            _cp.SetBossTrapSuggestions("Damage buffs: anything that can help you end the fight quickly can help you also survive.",1);
            _cp.SetBossTrapSuggestions("Defensive traps: she’s a pretty heavy and reliable hitter",2);
            _cp.SetBossSuggestions("Halja’s crows will spawn a chain that can stun you for a long time. Be careful to have enough stamina to dodge it");
            _cp.SetBossLore("Halja character design derives from Hel, legendary being who is said to preside over a realm of the same name, where she receives a " +
                            "portion of the dead. The two crows are a loose reference to Huginn and Munin, a pair of ravens that fly all over the world and bring " +
                            "information to the god Odin, and the chain is designed around Gleipnir, a magical chain built by dwarfs.");
            _cp.SetBossSprite(_haljaSprite);
        }

        private void SetupCaput()
        {
            _cp.SetBossName("Caputmallei");
            _cp.SetBossSubtitle("- Preacher of Dark Tales -");
            _cp.SetBossDescription("Boss that is pretty slow, but that has to be approached with caution, since he will have multiple ways to inflict damage to you: projectiles, " +
                                    "pools of blood on the ground, AoE attacks and an unavoidable, very powerful hit.");
            _cp.SetBossTrapSuggestions("Health regeneration: being healthy can save your life when facing unavoidable hits.",0);
            _cp.SetBossTrapSuggestions("Damage buffs: being pretty slow, hitting him results pretty consistent, so damage enhancers help you end the fight quickly.",1);
            _cp.SetBossTrapSuggestions("DamageOverArea traps: always tied to the slowness of the boss, they will inflict more damage since he will leave in more time.",2);
            _cp.SetBossSuggestions("Caputmallei charged attack is unavoidable, but can be interrupted if you attack him! Try to always keep a bit of stamina available to rush him down.");
            _cp.SetBossLore("Caputmallei design is full of references to Christianity and historical events like the Spanish inquisition and the crusades. The iron maiden on the bottom, " +
                            "the keys stuck in his back that represent the Keys to Heaven given by Jesus to St. Peter and the text from the Genesis written all over his body are some examples." +
                            "The name also has some historical relevancy: the Genoese Ghigærmo de ri Embrieghi was a merchant and military leader who played a fundamental role in the events of the " +
                            "First Crusade, and he was nicknamed Caput Mallei for his fame of indomitable warrior.");
            _cp.SetBossSprite(_caputmalleiSprite);
        }
        #endregion
    }
}
