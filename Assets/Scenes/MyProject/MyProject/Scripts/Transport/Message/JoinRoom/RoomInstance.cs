
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerInRoom
{
    public int Id;
    public string DisplayName;
    public string Avatar;

    public PlayerInRoom(int id, string displayName, string avatar)
    {
        Id = id;
        DisplayName = displayName;
        Avatar = avatar;
    }
    public PlayerInRoom()
    {
        Id = -1;
        DisplayName = "";
        Avatar = "";
    }
    public PlayerInRoom ConvertFromPlayerData(PlayerData player)
    {
        DisplayName = player.DisplayName;
        Avatar = player.Avatar;
        return this;
    }
}

public enum RoomType // quy định phòng nhỏ, to
{
    CREATEROOM,

}
public enum RoomStatus // quy định trạng thái của phòng
{
    NORMAL,
    MATCH,
}
[Serializable]
public class RoomInstance
{
    #region Thuộc tính
    public int RoomId;
    public PlayerInRoom HostPlayer;
    public List<PlayerInRoom> Players;
    public RoomType Type;
    public RoomStatus Status;
    #endregion
    #region Đối tượng
    public RoomInstance(int _id, PlayerInRoom _hostPlayer, RoomType roomType = RoomType.CREATEROOM, RoomStatus status = RoomStatus.NORMAL)
    {
        Players = new List<PlayerInRoom>();
        RoomId = _id;
        HostPlayer = _hostPlayer;
        Players.Add(_hostPlayer);
        Type = roomType;
        Status = status;
    }
    // tạo tin nhắn, sai phòng hoặc xin tạo phòng
    public RoomInstance()
    {
        Players = new List<PlayerInRoom>();
        RoomId = -1;
        HostPlayer = new PlayerInRoom(-1, "", "");
        Type = RoomType.CREATEROOM;
        Status = RoomStatus.NORMAL;
    }

    public void AddPlayer(PlayerInRoom player)
    {
        Players.Add(player);
    }
    public void ChangeHost(PlayerInRoom player)
    {
        if (Players.Contains(player))
        {
            HostPlayer = player;
        }
    }
    public void RemovePlayer(PlayerInRoom player)
    {
        Players.Remove(player);
    }
    #endregion
    #region Static Room
    public static int FindIndexRoomByIdRoom(int id, List<RoomInstance> rooms)
    {
        int lenght = rooms.Count;
        for (int i = 0; i < lenght; i++)
        {
            if (rooms[i].RoomId == id)
                return i;
        }
        return -1;
    }
    public static int GetNewRoomId(List<RoomInstance> rooms)
    {
        int idRoomRandom;
        bool thoaMan = false;
        do
        {
            idRoomRandom = UnityEngine.Random.Range(1, 1000);
            thoaMan = CheckRoomIdExist(idRoomRandom, rooms);
        }
        while (thoaMan);
        return idRoomRandom;
    }
    public static bool CheckRoomIdExist(int roomId, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (roomId == i.RoomId)
                return true;
        }
        return false;
    }
    public static RoomInstance FindRoomByHostId(int HostId, List<RoomInstance> rooms)
    {
        foreach (var i in rooms)
        {
            if (i.HostPlayer.Id == HostId)
                return i;


        }
        return null;
    }
    public static RoomInstance FindRoomByPlayerId(int id, List<RoomInstance> rooms, RoomType roomType = RoomType.CREATEROOM)
    {
        foreach (var i in rooms)
        {
            if (i.Type == roomType)
            {
                foreach (var j in i.Players)
                    if (j.Id == id)
                        return i;
            }
        }
        return null;
    }
    public static bool PlayerExistInRoom(PlayerInRoom player, RoomInstance room)
    {
        foreach (var j in room.Players)
            if (j.Id == player.Id)
                return true;
        return false;
    }
    #endregion
}