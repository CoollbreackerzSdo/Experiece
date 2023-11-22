using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
[MemoryDiagnoser]
public class RunLengthEncoding
{
    public Consumer Consumer = new();
    [Benchmark]
    public void REncode()
        => Consumer.Consume(Encode("AAAUUUUIOOOPPPLLLkKK"));
    [Benchmark]
    public void RDecode()
        => Consumer.Consume(Decode("3A4UI3O3P3Lk2K"));
    [Benchmark]
    public void xdqcEncode()
       => Consumer.Consume(Encode2("AAAUUUUIOOOPPPLLLkKK"));
    [Benchmark]
    public void xdqcDecode()
        => Consumer.Consume(Decode2("3A4UI3O3P3Lk2K"));
    public static string Decode2(string input) => Regex.Replace(input, @"(\d+)(\D)", m => new string(m.Groups[2].Value[0], int.Parse(m.Groups[1].Value)));
    public static string Encode2(string input) => Regex.Replace(input, @"(\D)\1+", m => m.Length.ToString() + m.Value[0]);
    public static string Encode(ReadOnlySpan<char> inputSpan)
    {
        var inputEncode = new StringBuilder();

        var carácter = new GroupCharacter
        {
            Apariciones = 1
        };

        for (int i = 0; i < inputSpan.Length; i++)
        {
            if (i == inputSpan.Length - 1)
            {
                carácter.Carácter = inputSpan[i];
                inputEncode.Append(carácter.ToStringValues());
                break;
            }

            if (inputSpan[i] != inputSpan[i + 1])
            {
                carácter.Carácter = inputSpan[i];
                inputEncode.Append(carácter.ToStringValues());
                carácter = new()
                {
                    Apariciones = 1
                };
            }
            else
            {
                carácter.Apariciones++;
            }
        }

        return inputEncode.ToString();
        //
    }
    private ref struct GroupCharacter
    {
        public char Carácter { get; set; }
        public int Apariciones { get; set; }
        public readonly string ToStringValues()
        {
            if (Apariciones > 1)
            {
                return string.Concat(Apariciones, Carácter);
            }
            else
            {
                return char.ToString(Carácter);
            }
        }
        public readonly StringBuilder ToCarácterRepeat()
        {
            StringBuilder builder = new();

            return builder.Append(Carácter, Apariciones);
        }
    }
    public static string Decode(ReadOnlySpan<char> inputSpan)
    {
        var result = new StringBuilder();

        var caracter = new GroupCharacter()
        {
            Apariciones = 1
        };

        string buffer = string.Empty;

        for (int i = 0; i < inputSpan.Length; i++)
        {
            if (i == inputSpan.Length - 1)
            {
                caracter.Carácter = inputSpan[i];
                if (buffer != string.Empty)
                    caracter.Apariciones += int.Parse(buffer) - 1;

                result.Append(caracter.ToCarácterRepeat());
                break;
            }

            bool isNumber = char.IsNumber(inputSpan[i]);

            if (!isNumber)
            {
                caracter.Carácter = inputSpan[i];

                if (buffer != string.Empty)
                    caracter.Apariciones += int.Parse(buffer) - 1;

                result.Append(caracter.ToCarácterRepeat());
                
                buffer = string.Empty;
                
                caracter.Apariciones = 1;
                
                continue;
            }
            else
            {
                buffer += inputSpan[i];
            }
        }

        return result.ToString();
    }
}