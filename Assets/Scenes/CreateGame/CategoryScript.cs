using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryScript : MonoBehaviour {
    public static List<int> categoriesSelected = new List<int>();

    public static void ToggleCategory(int cat) {
        if (categoriesSelected.Contains(cat)) {
            categoriesSelected.Remove(cat);
        }
        else {
            categoriesSelected.Add(cat);
        }
        foreach (var i in categoriesSelected) {
            print(i);
        }
    }
    
}