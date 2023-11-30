using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SelectmapController : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] Image img;
    [SerializeField] GameObject[] btn;
    int n = 0;
    // Start is called before the first frame update
    public void Next()
    {
        if(n < sprites.Length - 1)
        {
            n++;
            img.sprite = sprites[n];
            if(n == sprites.Length - 1)
            {
                btn[1].SetActive(false);
            }
            else
            {
                btn[1].SetActive(true);
            }
            btn[0].SetActive(true);
        }
    }
    public void Pre()
    {
        if(n > 0)
        {
            n--;
            img.sprite = sprites[n];
            if (n == 0)
            {
                btn[0].SetActive(false);
            }
            else
            {
                btn[0].SetActive(true);
            }
            btn[1].SetActive(true);
        }
    }
    public void LoadMap()
    {
        SceneManager.LoadScene(DataSet.nameScene[(int)MapIndex.map1 + n]);
    }
}
