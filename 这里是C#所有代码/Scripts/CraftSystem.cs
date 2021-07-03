using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftSystem : MonoBehaviour
{

    public List<Items> items = new List<Items>();
    public List<Items> craftableItems = new List<Items>();

    public bool isCrafting;
    public string currentCraftID;

    public List<InputField> craftInputs = new List<InputField>();
    public List<Image> craftImages = new List<Image>();

    public Image resultImage;
    public Sprite emptySlot;

    Items FetchItemByID(int _id)
    {
        for(int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == _id)
            {
                return items[i];
            }
        }
        return null;
    }


    Items FetchCraftItem(string _id)
    {
        for (int i = 0; i < craftableItems.Count; i++)
        {
            for(int j = 0; j < craftableItems[i].craftID.Count; j++)
            {
                if (craftableItems[i].craftID[j] == _id)
                {
                    return craftableItems[i];
                }
            }
        }
        return null;
    }


    void ConstractCraftItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].craftable==true)
            {
                craftableItems.Add(items[i]);
            }
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        ConstractCraftItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (isCrafting)
        {
            Craft();
        }
    }


    void Craft()
    {
        currentCraftID = "";
        for(int i = 0; i < craftInputs.Count; i++)
        {
            if (craftInputs[i].text != "")
            {
                currentCraftID += craftInputs[i].text;
                craftImages[i].sprite = FetchItemByID(int.Parse(craftInputs[i].text)).sprite;
            }
            else
            {
                currentCraftID += "";
                craftImages[i].sprite = emptySlot;
            }



            Items result = FetchCraftItem(currentCraftID);
            if (result != null)
            {
                resultImage.sprite = result.sprite;
            }
            else
            {
                resultImage.sprite = emptySlot;
            }


        }
    }




}








[System.Serializable]
public class Items
{
    public string name;
    public int ID;
    public Sprite sprite;
    public bool craftable;
  //  public string craftID;
    public List<string> craftID;
}