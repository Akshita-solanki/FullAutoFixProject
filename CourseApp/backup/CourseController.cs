using System;
public class CourseController
{
    public void HandleRequest()
    {
        try
        {
            string[] courses = new string[6]; // Increase the size of the array
            Console.WriteLine(courses[5]);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
            throw;
        }
    }
}
    }
}
