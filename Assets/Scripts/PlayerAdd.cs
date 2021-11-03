using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAdd : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = new PlayerData();
    [SerializeField] TMP_InputField _ifPlayerName;
    [SerializeField] TMP_InputField _ifPlayerAge;
    [SerializeField] TMP_Dropdown _ddPlayerType;
    [SerializeField] TextMeshProUGUI _textStatus;
    [SerializeField] PlayerList _playerList;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable()
    {
        ResetData();
    }
    public void SetPlayerName(string name)
    {
        _textStatus.text = string.Empty;
        _playerData.Name = name;
    }
    public void SetPlayerAge(string age)
    {
        _textStatus.text = string.Empty;
        try
        {
            _playerData.Age = int.Parse(age);
        }
        catch (System.Exception e)
        {
            _playerData.Age = 0;            
        }
    }
    public void SetPlayerType(int type)
    {
        _textStatus.text = string.Empty;
        _playerData.Type = _ddPlayerType.options[_ddPlayerType.value].text;
    }
    public void ResetData()
    {
        _playerData = new PlayerData();
        _ifPlayerName.text = string.Empty;
        _ifPlayerAge.text = string.Empty;
        _ddPlayerType.value = 0;
        _textStatus.text = string.Empty;

        //Debug.Log("Called : ResetData");
    }
    public void AddData()
    {
        if (string.IsNullOrWhiteSpace(_playerData.Name))
        {
            _textStatus.text = "Invaid Player Name!";
            return;
        }
        if (_playerData.Age == 0)
        {
            _textStatus.text = "Invalid Player Age!";
            return;
        }
        if (string.IsNullOrEmpty(_playerData.Type))
        {
            _textStatus.text = "Invalid Player Type!";
            return;
        }
        else
        {
            _playerList.AddPlayer(_playerData);
            _playerList.AddItemToListView(_playerData);
            _textStatus.text = "Player Added Successfully!";
            ResetData();
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Age;
    public string Type;
}
