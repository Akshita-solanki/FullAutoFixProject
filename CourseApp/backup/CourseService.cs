using System;
using System.Linq;
using System.Collections.Generic;

public class CourseService
{
    public void Divide()
int a = 10;
int b = 0;
if (b != 0)
{
    int result = a / b;
}

public void NullCheck()
{
    string instructor = null;
    if (instructor != null)
    {
        Console.WriteLine(instructor.Length);
    }
}

    public void FindCourse()
    {
        List<string> courses = new List<string>();
        var course = courses.First(c => c == "Math"); // InvalidOperationException
    }
}
