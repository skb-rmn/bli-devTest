using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerAdd : MonoBehaviour
{
    [SerializeField] PlayerData playerData = new PlayerData();
    [SerializeField] TMP_InputField _ifPlayerName;
    [SerializeField] TMP_InputField _ifPlayerAge;
    [SerializeField] TMP_Dropdown _ddPlayerType;
    [SerializeField] TextMeshProUGUI _textStatus;
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
        playerData.Name = name;
    }
    public void SetPlayerAge(string age)
    {
        _textStatus.text = string.Empty;
        try
        {
            playerData.Age = int.Parse(age);
        }
        catch (System.Exception e)
        {
            playerData.Age = 0;            
        }
    }
    public void SetPlayerType(int type)
    {
        _textStatus.text = string.Empty;
        playerData.Type = type;
    }
    public void ResetData()
    {
        _ifPlayerName.text = string.Empty;
        _ifPlayerAge.text = string.Empty;
        _ddPlayerType.value = 0;
        _textStatus.text = string.Empty;

        //Debug.Log("Called : ResetData");
    }
    public void AddData()
    {
        if (string.IsNullOrWhiteSpace(playerData.Name))
        {
            _textStatus.text = "Invaid Player Name!";
            return;
        }
        if (playerData.Age == 0)
        {
            _textStatus.text = "Invalid Player Age!";
            return;
        }
        if (playerData.Type == 0)
        {
            _textStatus.text = "Invalid Player Type!";
            return;
        }
        else
        {
            _textStatus.text = "Player Added Successfully!";
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public string Name;
    public int Age;
    public int Type;
}
