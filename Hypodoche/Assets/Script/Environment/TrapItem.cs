using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapItem : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _itemPrefab;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private string _itemName;
    [SerializeField] private int _ownedAmount = 0;
    [SerializeField] private string _description;
    [SerializeField] private int _effectNum;
    [SerializeField] private Sprite _effectOneSprite;
    [SerializeField] private string _effectOneDescription;
    [SerializeField] private Sprite _effectTwoSprite;
    [SerializeField] private string _effectTwoDescription;
    #endregion

    #region Getter and Setter
    public Sprite GetItemSprite()
    {
        return _itemSprite;
    }

    public string GetItemName()
    {
        return _itemName;
    }
    public int GetOwnedAmount()
    {
        return _ownedAmount;
    }

    public GameObject GetPrefab()
    {
        return _itemPrefab;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetEffectNum()
    {
        return _effectNum;
    }

    public Sprite GetEffectOneSprite()
    {
        return _effectOneSprite;
    }
    public string GetEffectOneDescription()
    {
        return _effectOneDescription;
    }
    public string GetEffectTwoDescription()
    {
        return _effectTwoDescription;
    }
    public Sprite GetEffectTwoSprite()
    {
        return _effectTwoSprite;
    }

    public void SetOwnedCount(int amount)
    {
        _ownedAmount = amount;
    }
    
    #endregion

    #region Methods
    public void IncreaseOwnedCount()
    {
        _ownedAmount++;
    }

    public void DecreaseOwnedCount()
    {
        _ownedAmount--;
    }
    #endregion
}
