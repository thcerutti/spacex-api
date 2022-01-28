using SpaceX.Api.Models.Input;

namespace SpaceX.Api.Models.Output
{
    public class RocketOutputInfo
    {
        public string? Name { get; set; }
        public string[]? FlickrImages { get; set; }

        public RocketOutputInfo(RocketInputInfo rocketInfo)
        {
            Name = rocketInfo.Name;
            FlickrImages = rocketInfo.FlickrImages;
        }
    }
}