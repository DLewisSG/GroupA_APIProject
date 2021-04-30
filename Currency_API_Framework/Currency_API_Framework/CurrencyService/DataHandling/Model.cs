
public class SingleCurrencyToAnotherResponse
{
    public Currency bitcoin { get; set; }
    public Currency eos { get; set; }
    public Currency iota { get; set; }
}

public class Currency
{
    public int usd { get; set; }
}
