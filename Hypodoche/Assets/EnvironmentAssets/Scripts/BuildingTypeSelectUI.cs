using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    
    [SerializeField] private List<BuildingTypeSO> buildingTypeSOList;
    //[SerializeField] private List<ButtonTypeSO> buttonTypeSOList;
    
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private ItemDatabase itemDatabase;
    private List<Transform> buildingBtn;
    private void Start()
    {

            Transform buildingBtnTemplate = transform.Find("buildingBtnTemplate");
            buildingBtn= new List<Transform>();
            int index = 0;
            foreach (BuildingTypeSO buildingTypeSO in buildingTypeSOList)
             { 
                 Transform buildingBtnTransform = Instantiate(buildingBtnTemplate, transform);
                 buildingBtnTransform.gameObject.SetActive(false);
                 buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 60, 0);
                 buildingBtnTransform.Find("image").GetComponent<Image>().sprite = buildingTypeSO.sprite;
                 buildingBtnTransform.GetComponent<Button>().onClick.AddListener(() =>
                    {
                        buildingManager.SetActiveBuildingType(buildingTypeSO);
                        Debug.Log("The active type is"+ buildingTypeSO);
                        buildingManager.SetCurrentAction("Build");
                    });
                 buildingBtn.Add(buildingBtnTransform);
                 index++;
            }
            buildingBtnTemplate.GetComponent<Button>().onClick.AddListener(() =>
            {   
                buildingBtnTemplate.gameObject.SetActive(false);
                foreach (Transform btn in buildingBtn)
                {
                    btn.gameObject.SetActive(true);
                }
            });
            
            
            /*
            
            // turn back button
            Transform buildingBtnBack = Instantiate(buildingBtnTemplate, transform);
            buildingBtnBack.gameObject.SetActive(false);
            
            index++;
            buildingBtnBack.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 60, 0);
            buildingBtnBack.Find("image").GetComponent<Image>().sprite = buttonTypeSOList[0].sprite;
            buildingBtnBack.GetComponent<Button>().onClick.AddListener(() =>
            {
                
                foreach (Transform btn in buildingBtn)
                {
                    btn.gameObject.SetActive(false);
                }
                buildingBtnTemplate.gameObject.SetActive(true);
            });
            buildingBtn.Add(buildingBtnBack);
            
            // delete button
            Transform buildingBtnDelete = Instantiate(buildingBtnTemplate, transform);
            buildingBtnDelete.gameObject.SetActive(false);
            index++;
            buildingBtnDelete.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 60, 0);
            buildingBtnDelete.Find("image").GetComponent<Image>().sprite = buttonTypeSOList[1].sprite;
            buildingBtnDelete.GetComponent<Button>().onClick.AddListener(() => { buildingManager.SetCurrentAction("Delete");});
            buildingBtn.Add(buildingBtnDelete);
                
            // move button
            Transform buildingBtnMove = Instantiate(buildingBtnTemplate, transform);
            buildingBtnMove.gameObject.SetActive(false);
            index++;
            buildingBtnMove.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 60, 0);
            buildingBtnMove.Find("image").GetComponent<Image>().sprite = buttonTypeSOList[2].sprite;
            buildingBtnMove.GetComponent<Button>().onClick.AddListener(() => { buildingManager.SetCurrentAction("MoveFrom");});
            buildingBtn.Add(buildingBtnMove);
            
            */
            
    }
}
