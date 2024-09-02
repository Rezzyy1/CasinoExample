using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[] skinPrices; // Цены на скины
    public Button[] skinButtons; // Кнопки для покупки и выбора скинов
    public Text[] buttonTexts; // Тексты на кнопках для изменения надписи с ценой или "Выбрать"
    public Text moneyText; // Текст для отображения текущих очков
    private int currentMoney;

    public Button defaultSkinButton; // Кнопка для выбора стандартного скина
    public Text defaultButtonText; // Текст на кнопке для стандартного скина

    void Start()
    {
        // Загрузка сохраненных данных
        currentMoney = PlayerPrefs.GetInt("TotalScore", 0);
        moneyText.text = "Money: " + currentMoney.ToString();

        // Инициализация кнопок скинов
        for (int i = 0; i < skinButtons.Length; i++)
        {
            if (PlayerPrefs.GetInt("Skin" + i, 0) == 1) // Проверяем, куплен ли скин
            {
                // Если куплен, меняем текст кнопки на "Выбрать"
                buttonTexts[i].text = "Equip";
                int index = i; // Сохраняем индекс для использования в лямбда-выражении
                skinButtons[i].onClick.AddListener(() => SelectSkin(index));
            }
            else
            {
                // Если не куплен, отображаем цену
                buttonTexts[i].text = skinPrices[i].ToString();
                int index = i; // Сохраняем индекс для использования в лямбда-выражении
                skinButtons[i].onClick.AddListener(() => BuySkin(index));
            }
        }

        // Инициализация кнопки для стандартного скина
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
            PlayerPrefs.SetInt("Skin" + skinIndex, 1); // Сохраняем, что скин куплен
            PlayerPrefs.Save();

            moneyText.text = "Money: " + currentMoney.ToString();

            // Обновляем кнопку после покупки
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
        if (skinIndex == -1) // Выбор стандартного скина
        {
            PlayerPrefs.SetInt("SelectedSkin", skinIndex);
            PlayerPrefs.Save();
            Debug.Log("Standard skin selected!");
        }
        else if (PlayerPrefs.GetInt("Skin" + skinIndex, 0) == 1) // Проверяем, куплен ли скин
        {
            PlayerPrefs.SetInt("SelectedSkin", skinIndex); // Сохраняем выбранный скин
            PlayerPrefs.Save();
            Debug.Log("Skin " + skinIndex + " selected!");
        }
        else
        {
            Debug.Log("This skin is not purchased yet!");
        }
    }
}


