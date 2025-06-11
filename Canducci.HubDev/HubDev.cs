namespace Canducci.HubDev
{
    public sealed class HubDev
    {
        public HubDev(string token)
        {
            Token = token;
        }
        public string Token { get; private set; }
    }
}
