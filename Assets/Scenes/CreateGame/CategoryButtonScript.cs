﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryButtonScript : MonoBehaviour {
    public int cat;

    public void onClick() {
        CategoryScript.ToggleCategory(cat);
    }
}