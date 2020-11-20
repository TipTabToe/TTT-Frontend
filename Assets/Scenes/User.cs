using System;
using System.Collections.Generic;

[Serializable]
public class User {
    public long id;
    public string username;
    public string password;
    public int points;
    public List<Statistic> statistics;
    public List<long> friends;
    public List<long> pendingFriends;
    public List<long> pendingRequests;

    public override string ToString() {
        return $"{nameof(id)}: {id}, {nameof(username)}: {username}, {nameof(password)}: {password}, {nameof(points)}: {points}, {nameof(statistics)}: {statistics}, {nameof(friends)}: {friends}, {nameof(pendingFriends)}: {pendingFriends}, {nameof(pendingRequests)}: {pendingRequests}";
    }
}