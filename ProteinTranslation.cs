public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        if (string.IsNullOrEmpty(strand) || strand.Length % 3 != 0) return [];
        
        var proteins = new List<string>();
        for (int i = 0; i < strand.Length; i += 3)
        {
            var udnMach = strand.Substring(i, 3);
            if (udnMach.Length == 3)
            {
                switch (udnMach)
                {
                    case "AUG":
                        proteins.Add("Methionine");
                        continue;
                    case "UUU" or "UUC":
                        proteins.Add("Phenylalanine");
                        continue;
                    case "UUA" or "UUG":
                        proteins.Add("Leucine");
                        continue;
                    case "UCU" or "UCC" or "UCA" or "UCG":
                        proteins.Add("Serine");
                        continue;
                    case "UAU" or "UAC":
                        proteins.Add("Tyrosine");
                        continue;
                    case "UGU" or "UGC":
                        proteins.Add("Cysteine");
                        continue;
                    case "UGG":
                        proteins.Add("Tryptophan");
                        continue;
                    case "UAA" or "UAG" or "UGA":
                        break;
                    default:
                        continue;
                }
            }
        }

        return [.. proteins];
    }
}