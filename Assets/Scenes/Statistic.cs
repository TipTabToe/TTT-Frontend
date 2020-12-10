using System;
using System.Collections.Generic;

[Serializable]
// Contains information of statistics
public class Statistic {
    public long id;
    public int answers;
    public int correctAnswers;
    public Category category;
}