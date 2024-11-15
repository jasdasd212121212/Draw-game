public class GoogleTranlateParser
{
    public string Parse(string rawResponse) => rawResponse.Substring(4, GetEndIndex(rawResponse) - 4);
    
    private int GetEndIndex(string rawResponse)
    {
        return rawResponse.IndexOf(GoogleTranslateParserConfig.END_SYMBOL);
    }
}