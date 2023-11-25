using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManHinhChinh : MonoBehaviour
{
    [Header("-----------Tien----------\n")]
    [SerializeField] TextMeshProUGUI[] txtItem;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < txtItem.Length; i++)
        {
            txtItem[i].text = DataSet.item[i] + "";
        }
    }
    public void Shop()
    {
        SceneManager.LoadScene(DataSet.nameScene[(int)MapIndex.shop]);
    }
    public void Map()
    {
        SceneManager.LoadScene(DataSet.nameScene[(int)MapIndex.chonMap]);
    }
}
