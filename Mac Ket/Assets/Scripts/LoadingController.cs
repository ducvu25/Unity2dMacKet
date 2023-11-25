using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingController : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] float delta;
    [SerializeField] TextMeshProUGUI txtLoad;
    float _delta;
    string[] text = { "Loading", "Loading .", "Loading . .", "Loading . . ." };
    int n;
    // Start is called before the first frame update
    void Start()
    {
        img.fillAmount = 0;
        _delta = 0;
        n = 0;
        txtLoad.text = text[n];
    }

    // Update is called once per frame
    void Update()
    {
        if(_delta > 0)
        {
            _delta -= Time.deltaTime;
            return;
        }
        n = (n + 1) % text.Length;
        txtLoad.text = text[n];
        _delta = delta;
        if((int)Random.Range(0, 3) == 1)
            img.fillAmount += Random.Range(0, 0.2f);
        if(img.fillAmount >= 1)
        {
            SceneManager.LoadScene(DataSet.nameScene[(int)MapIndex.manHinhChinh]);
        }
    }
}
