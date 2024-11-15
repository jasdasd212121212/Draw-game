public class GoogleQueryPreparer
{
    public string Prepare(string raw) => raw.Replace(GoogleTranslateParserConfig.END_SYMBOL, "");
}