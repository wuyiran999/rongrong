using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class ItemManager : MonoBehaviour
{
    public Button randomBtn;
    private List<Item> itemList;
    // Start is called before the first frame update
    void Start()
    {
        randomBtn.onClick.AddListener(OnRandomSort);
        itemList = GetComponentsInChildren<Item>().ToList();

    }

    private void OnRandomSort()
    {

        foreach (var item in itemList)
        {
            int index = Random.Range(0, itemList.Count);
            item.transform.SetSiblingIndex(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
