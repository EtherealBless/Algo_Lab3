using Lab3.LabCollections.YunPart.PolishNotation.Clases;

public class Variable : Token
{
    public char VariableName { get; set; }

    public Variable(char variableName)
    {
        VariableName = variableName;
    }
}
