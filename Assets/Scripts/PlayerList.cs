using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerList : MonoBehaviour
{
    [SerializeField] List<PlayerData> _playerList = new List<PlayerData>();
    [SerializeField] Transform _listContent;
    [SerializeField] TextMeshProUGUI _statusText;
    [SerializeField] TMP_InputField _searchField;
    [SerializeField] GameObject _listItemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ClearListContent();

        _playerList.Add(new PlayerData { Name = "Shakib Al Hasan", Age = 24, Type = "All-rounder" });
        _playerList.Add(new PlayerData { Name = "QAz", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "Binod", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "xzc", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "AdfsSD", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "hjgh", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "jhghg", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "trty", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "vbnbnv", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "vbjnmmh", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "nmbmnbm", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "trytryu", Age = 24, Type = "Batsman" });
        _playerList.Add(new PlayerData { Name = "oippopo", Age = 24, Type = "Batsman" });
        //_playerList = Util.Instance.LoadData();
        LoadDataFromList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ClearListContent()
    {
        for (int i = 0; i < _listContent.childCount; i++)
        {
            Destroy(_listContent.transform.GetChild(i).gameObject);
        }
    }
    public void AddItemToListView(PlayerData data)
    {
        GameObject go = Instantiate<GameObject>(_listItemPrefab, _listContent);
        go.GetComponent<ListItem>().SetPlayerData(data);
        go.SetActive(true);
        go = null;
    }
    public void AddPlayer(PlayerData player)
    {
        _playerList.Add(player);
    }
    public void LoadDataFromList()
    {
        if (_playerList.Count == 0)
        {
            return;
        }
        for (int i = 0; i < _playerList.Count; i++)
        {
            AddItemToListView(_playerList[i]);
        }
    }
    public void SearchPlayer(string searchParam)
    {
        _statusText.SetText(string.Empty);
        if (_playerList.Count > 0)
        {
            if (!string.IsNullOrWhiteSpace(searchParam))
            {
                ClearListContent();
                foreach (PlayerData player in _playerList)
                {
                    if (player.Name.ToLower().Contains(searchParam.Trim().ToLower()))
                    {
                        AddItemToListView(player);
                    }
                }
            }
            else
            {
                ClearListContent();
                _statusText.SetText(string.Empty);
                LoadDataFromList();
            }
            
        }
    }
    private void OnApplicationQuit()
    {
        if (_playerList.Count > 0)
        {
            Util.Instance.SaveData(_playerList);
        }
        else
        {
            Util.Instance.ResetData();
        }
    }
    public void SaveToFile()
    {
        Util.Instance.SaveData(_playerList);
    }
    public void ClearData()
    {
        ClearListContent();
        _playerList.Clear();
        //Util.Instance.ResetData();
    }
    public void LoadDataFromFile()
    {
        _playerList = Util.Instance.LoadData();
    }
}
