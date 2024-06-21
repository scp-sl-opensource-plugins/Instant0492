using Exiled.API.Interfaces;

namespace Instant0492
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
        public bool EnableFor0492 { get; set; } = false;
        public uint Limit { get; set; } = 5;
    }
}