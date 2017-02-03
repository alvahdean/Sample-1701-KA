using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_1701_KA
{
    public static class CodeRequirements
    {
        static CodeRequirements()
        {
            Author="Dean Fuqua";
            Email = "alvahdean@gmail.com";
            CodeHours = 1.5;
            CodeStart = new DateTime(2017, 01, 17);
            Requirments = new StringBuilder()
                .AppendLine("Create the necessary C# library code to perform the following tasks.")
                .AppendLine("1.Accept a string of text as input.")
                .AppendLine("2.Analyze that string of text and return the following information")
                .AppendLine("a.Total count of words.")
                .AppendLine("b.Total count of unique words.")
                .AppendLine("c.Alphabetized List of unique words.")
                .AppendLine("d.Total count of each unique word.")
                .AppendLine()
                .AppendLine("The functionality should be coded in such a way that it can be tested easily and reused by other modules.  The code should be efficient, properly documented and of course semantically correct.Hyphenated words count as one word.Do not include punctuation.  How you structure the library is up to you.How you pass the parameters and retrieve the results are up to you.If you feel you do not have enough requirements to finish this, make some decisions and go with them.Be prepared to explain why you chose what you did.  The formatted output below is just an example.Since this is to be a library, I don't care about the formatting of the output, just return something that can be consumed by another application or library.")
                .ToString();
        }

        static public string Requirments { get; set; }
        static public string Author { get; set; }
        static public string Email { get; set; }
        static public DateTime CodeStart { get; set; }
        static public double CodeHours { get; set; }
        static public string ToString()
        {
            return new StringBuilder()
                .AppendLine($"Author: {Author}")
                .AppendLine($"Email: {Email}")
                .AppendLine($"Code Start: {CodeStart.ToShortDateString()}")
                .AppendLine($"Code Time (hours): {Math.Round(CodeHours, 1)}")
                .AppendLine($"Requirements:")
                .AppendLine(Requirments)
                .ToString();
        }
    }
}
