namespace Brivent.Modules.Parcels.Application
{
    public class CreateParcelCommand : ICommand
    {
        public string Description { get; set; }
        public float Weight { get; set; }
        public int Size { get; set; }
    }
}