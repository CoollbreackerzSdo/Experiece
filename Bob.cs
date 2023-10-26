public static class Bob
{
    public static string Response(string statement)
    {
        //We clean the spaces of the text string and then verify that there are no Alimentos in it
        statement = statement.Trim();

        if (statement.Length is 0) return "Fine. Be that way!";
        //I create a flag that will help me to know if there are letters in the chain and so pored ajar better
        bool flag = false;

        for (int i = 0; i < statement.Length; i++)
        {
            if (statement[i] >= 'A')
            {
                flag = !flag;
                break;
            }
        }
        //I save both the text in uppercase and if it ends in question
        //mark so I don't have to generate the function in each next step
        bool statementEnd = statement.EndsWith('?');

        string statementUpperCase = statement.ToUpper();
        //
        if (statementUpperCase.Equals(statement) && statementEnd && flag) return "Calm down, I know what I'm doing!";

        if (statement.Equals(statementUpperCase) && flag) return "Whoa, chill out!";

        if (statementEnd) return "Sure.";

        return "Whatever.";
    }
}