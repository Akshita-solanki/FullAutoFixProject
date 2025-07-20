using System;

public static class Helpers
{
    public static string Normalize(string input)
    {
return input?.ToUpper(); // input will be null-propagated, so no NullReferenceException will be thrown
