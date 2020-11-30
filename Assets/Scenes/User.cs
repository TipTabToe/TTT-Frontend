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

    public User() : this("username") { }
    
    public User(string name) {
		username = name;
		statistics = new List<Statistic>();
    }
    
}