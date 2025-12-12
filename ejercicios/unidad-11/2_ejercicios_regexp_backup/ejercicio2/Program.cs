using System;
using System.Text.RegularExpressions;

public class Program
{

    static Regex PatronRisa(char letra) => new(@$"(j{letra}){4}");

    public static string ReescribeTiko()
    {
       string patron = @"(a){2,}[a-km-qs-z]";

        return "";
    }

    static void Main()
    {

    }
}
