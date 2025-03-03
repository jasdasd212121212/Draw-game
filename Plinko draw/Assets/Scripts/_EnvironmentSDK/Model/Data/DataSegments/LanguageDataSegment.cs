public class LanguageDataSegment : EnvironmentDataSegment
{
    public string IsoCode { get; private set; }

    public LanguageDataSegment(string isoCode)
    {
        IsoCode = isoCode;
    }
}