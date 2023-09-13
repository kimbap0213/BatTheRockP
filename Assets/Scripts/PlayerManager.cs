using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] protected TMPro.TMP_Text _text;
    protected int _nowTurnIndex = 0;
    protected List<Player> _playerList = new List<Player>();
    protected List<string> _playerResult = new List<string>();
    [SerializeField] GameObject _projectile;

    public void AddPlayer(Player player)
    {
        _playerList.Add(player);
        if(_playerList.Count >= 8)
        {
            NextTurn();
        }
    }

    public void NextTurn()
    {
        _nowTurnIndex = (_nowTurnIndex + 1) % _playerList.Count;
        _playerList[_nowTurnIndex].StartAttack();
    }

    public Player GetRandomPlayer(Player player)
    {
        if(_playerList.Count != 1)
        {
            int ReturnIndex = Random.Range(0, _playerList.Count - 1);
            if (ReturnIndex >= _playerList.IndexOf(player))
            {
                ReturnIndex++;
            }
            return _playerList[ReturnIndex];
        }
        else
        {
            return null;
        }
    }

    public GameObject GetProjectilePrefap()
    {
        return _projectile;
    }

    public void DestroyPlayer(Player player)
    {
        _playerResult.Add(player.name);
        _playerList.Remove(player);
        if(_playerList.Count == 1)
        {
            _text.text += "1. " + _playerList[0].name + "\n";
            for(int i = _playerResult.Count - 1; i>=0; i++)
            {
                _text.text += (_playerResult.Count - i + 1).ToString() + _playerResult[i] + "\n";
            }
        }
    }
}
