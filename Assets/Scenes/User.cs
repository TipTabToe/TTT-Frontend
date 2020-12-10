using System;
using System.Collections.Generic;

[Serializable]
// Contains all the information of user
public class User {
    /*
	public long id;
    public string username;
    public string password;
    */
    public int points;
    public List<Statistic> statistics;
    /*
    public List<long> friends;
    public List<long> pendingFriends;
    public List<long> pendingRequests;
	*/
    
    // Constructor for user
    public User() {
	    statistics = new List<Statistic>();
    }

    // Overrides default ToString for user
    public override string ToString() {
	    return "User points: " + points;
    }
}