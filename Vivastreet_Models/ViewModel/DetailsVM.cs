namespace Vivastreet_Models.ViewModel
{
    public class DetailsVM
    {
        public DetailsVM()
        {
            Advertisementz = new Advertisement();
            Imagez = new Image();
        }
        public Advertisement Advertisementz { get; set; }
        public Image Imagez { get; set; }
    }
}
