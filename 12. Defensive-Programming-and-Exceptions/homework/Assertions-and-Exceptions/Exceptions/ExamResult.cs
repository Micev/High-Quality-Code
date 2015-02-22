using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;
    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {      
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }

    public int Grade {
        get
        {
            return this.Grade;
        }
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("grade","should be positive number.");
            }
            this.grade = value;
        }
    }

    public int MinGrade 
    { 
        get
        {
            return this.minGrade;
        }
        private set 
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("minGrade", " should be positive number.");
            }
            this.minGrade = value;
        }
    }

    public int MaxGrade { 
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("maxGrade"," should be positive number.");
            }
            if (maxGrade <= minGrade)
            {
                throw new ArithmeticException("The minGrade should be less than maxGrade.");
            }
            this.maxGrade = value
        } 
    }

    public string Comments 
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (string.IsNullOrEmpty(comments))
            {
                throw new ArgumentNullException(comments,"should be non-empty string.");
            }
            this.comments = value;
        }
    }
}
