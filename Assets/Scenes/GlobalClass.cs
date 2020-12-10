using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is used to save all the important information
public static class GlobalClass {
    public const string API_URL = "http://ec2-18-192-24-188.eu-central-1.compute.amazonaws.com/api";
    public static User player;
    public static int lastRoundPoints = 0;
    public static int category = 1;
}