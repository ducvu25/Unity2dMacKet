using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShopController : MonoBehaviour
{
    [Header("--------------Coin---------")]
    [SerializeField] TextMeshProUGUI[] txtCoinTotals;
    [Header("---------Information--------")]
    [SerializeField] GameObject goInformationItem;
    [SerializeField] Image imgItem;
    [SerializeField] TextMeshProUGUI txtNameItem;
    [SerializeField] TextMeshProUGUI txtInformationItem;
    [SerializeField] TextMeshProUGUI txtNumber;
    [SerializeField] TextMeshProUGUI txtPrice;
    [SerializeField] Image imgCoin;

    [Header("\n---------Setting--------")]
    [SerializeField] Sprite[] imgItems;
    string[] nameItem = { "Mạng", "Thời gian", "Kim cương", "Xu", "Quà ngẫu nhiên", "Nam châm" };
    string[] informationItem = {"Mạng sẽ được dùng sau khi chết 3 lần\nHệ thống sẽ xác nhận trước khi sử dụng mạng đã mua",
        "Với một lần mua được 15s\n Tự động công thời gian đã mua vào màn tiếp theo.",
        "1 ngày tối đa mua được 3 lần\n (Không tính dồn vào ngày hôm sau)",
        "1 ngày tối đa mua được 3 lần\n (Không tính dồn vào ngày hôm sau)",
        "Mở ra những món quà ngẫu nhiên\n (Giá trị có thể lớn hoặc nhỏ)",
        "Hút xu trong phạm vi nhất định\n Có hiệu lực trong vòng 7s"};
    int[] price = { 100, 200, 1000, 10, 50, 200 };
    int[] typeCoin = { 1, 0, 0, 1, 1, 0 };
    int[] number = { 1, 1, 1, 100, 1, 1 };
    [SerializeField] Sprite[] imgCoins;


    int type;
    int n;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < txtCoinTotals.Length; i++)
        {
            txtCoinTotals[i].text = DataSet.item[i] + "";
        }
        goInformationItem.SetActive(false);
    }

    public void ClickItem(int i)
    {
        n = 1;
        type = i;
        goInformationItem.SetActive(true);
        imgItem.sprite = imgItems[i];
        txtNameItem.text = nameItem[i];
        txtInformationItem.text = informationItem[i];
        txtNumber.text = number[i] +"";
        txtPrice.text = price[i] + "";
        imgCoin.sprite = imgCoins[typeCoin[i]];
    }
    public void Pay()
    {
        if(price[type] * n < DataSet.item[1 + typeCoin[type]])
        {
            DataSet.item[1 + typeCoin[type]] -= price[type] * n;
            switch (type)
            {
                case 0:
                    {
                        DataSet.item[0] += n * number[type];
                        break;
                    }
                case 1:
                    {
                        DataSet.item[3] += n * number[type];
                        break;
                    }
                case 2:
                    {
                        DataSet.item[2] += n * number[type];
                        break;
                    }
                case 3:
                    {
                        DataSet.item[1] += n * number[type];
                        break;
                    }
                case 4:
                    {
                        //DataSet.item[0] += n * number[type];
                        break;
                    }
                case 5:
                    {
                        DataSet.item[4] += n * number[type];
                        break;
                    }
            }
            for (int i = 0; i < txtCoinTotals.Length; i++)
            {
                txtCoinTotals[i].text = DataSet.item[i] + "";
            }
        }
    }
    public void Increase()
    {
        if(n < 98)
        {
            n++;
            txtNumber.text = number[type]*n + "";
            txtPrice.text = price[type]*n + "";
        }
    }
    public void Decrease()
    {
        if (n > 1)
        {
            n--;
            txtNumber.text = number[type] * n + "";
            txtPrice.text = price[type] * n + "";
        }
    }
    public void Back()
    {
        SceneManager.LoadScene(DataSet.nameScene[(int)MapIndex.manHinhChinh]);
    }
}
