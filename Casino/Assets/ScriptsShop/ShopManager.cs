using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[] skinPrices; // ���� �� �����
    public Button[] skinButtons; // ������ ��� ������� � ������ ������
    public Text[] buttonTexts; // ������ �� ������� ��� ��������� ������� � ����� ��� "�������"
    public Text moneyText; // ����� ��� ����������� ������� �����
    private int currentMoney;

    public Button defaultSkinButton; // ������ ��� ������ ������������ �����
    public Text defaultButtonText; // ����� �� ������ ��� ������������ �����

    void Start()
    {
        // �������� ����������� ������
        currentMoney = PlayerPrefs.GetInt("TotalScore", 0);
        moneyText.text = "Money: " + currentMoney.ToString();

        // ������������� ������ ������
        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Skin" + i, 0) == 1) // ���������, ������ �� ����
            {
                // ���� ������, ������ ����� ������ �� "�������"
                buttonTexts[i].text = "Equip";
                int index = i; // ��������� ������ ��� ������������� � ������-���������
                skinButtons[i].onClick.AddListener(() => SelectSkin(index));
            }
            else
            {
                // ���� �� ������, ���������� ����
                buttonTexts[i].text = skinPrices[i].ToString();
                int index = i; // ��������� ������ ��� ������������� � ������-���������
                skinButtons[i].onClick.AddListener(() => BuySkin(index));
            }
        }

        // ������������� ������ ��� ������������ �����
        defaultButtonText.text = "Equip";
        defaultSkinButton.onClick.AddListener(() => SelectSkin(-1));
    }

    public void BuySkin(int skinIndex)
    {
        int price = skinPrices[skinIndex];
        if (currentMoney >= price)
        {
            currentMoney -= price;
            PlayerPrefs.SetInt("TotalScore", currentMoney);
            PlayerPrefs.SetInt("Skin" + skinIndex, 1); // ���������, ��� ���� ������
            PlayerPrefs.Save();

            moneyText.text = "Money: " + currentMoney.ToString();

            // ��������� ������ ����� �������
            buttonTexts[skinIndex].text = "Equip";
            skinButtons[skinIndex].onClick.RemoveAllListeners();
            skinButtons[skinIndex].onClick.AddListener(() => SelectSkin(skinIndex));
        }
        else
        {
            Debug.Log("Not enough money to buy this skin!");
        }
    }

    public void SelectSkin(int skinIndex)
    {
        if (skinIndex == -1) // ����� ������������ �����
        {
            PlayerPrefs.SetInt("SelectedSkin", skinIndex);
            PlayerPrefs.Save();
            Debug.Log("Standard skin selected!");
        }
        else if (PlayerPrefs.GetInt("Skin" + skinIndex, 0) == 1) // ���������, ������ �� ����
        {
            PlayerPrefs.SetInt("SelectedSkin", skinIndex); // ��������� ��������� ����
            PlayerPrefs.Save();
            Debug.Log("Skin " + skinIndex + " selected!");
        }
        else
        {
            Debug.Log("This skin is not purchased yet!");
        }
    }
}


