using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ListItem : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _playerName;
    [SerializeField] TextMeshProUGUI _playerAge;
    [SerializeField] TextMeshProUGUI _playerType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPlayerData(PlayerData playerData)
    {
        _playerName.SetText(playerData.Name);
        _playerAge.SetText(string.Format("{0} Years", playerData.Age));
        _playerType.SetText(playerData.Type);
    }
    public void ClearData()
    {
        _playerName.SetText(string.Empty);
        _playerAge.SetText(string.Empty);
        _playerType.SetText(string.Empty);
    }
}
