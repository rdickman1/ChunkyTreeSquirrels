using Photon.Pun;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShipNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField shipNameInputField = null;
    [SerializeField] private Button readyButton = null;

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start()
    {
        SetUpInputField();
    }

    private void SetUpInputField()
    {
        if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

        shipNameInputField.text = defaultName;

        SetShipName(defaultName);
    }

    public void SetShipName(string name)
    {
        readyButton.interactable = !string.IsNullOrEmpty(name);

    }

    public void SaveShipName()
    {
        string shipName = shipNameInputField.text;

        PhotonNetwork.NickName = shipName;

        PlayerPrefs.SetString(PlayerPrefsNameKey, shipName);
    }
}
