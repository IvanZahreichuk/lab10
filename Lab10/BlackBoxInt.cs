namespace Lab10;

class BlackBoxInt
{
    private int _innerValue;

    private BlackBoxInt()
    {
        this._innerValue = 0;
    }

    private void Add(int inputValue)
    {
        this._innerValue += inputValue;
    }

    private void Subtract(int inputValue)
    {
        this._innerValue -= inputValue;
    }

    private void Multiply(int inputValue)
    {
        this._innerValue *= inputValue;
    }

    private void Divide(int inputValue)
    {
        this._innerValue /= inputValue;
    }

    private void LeftShift(int shiftsCount)
    {
        this._innerValue <<= shiftsCount;
    }

    private void RightShift(int shiftsCount)
    {
        this._innerValue >>= shiftsCount;
    }
}