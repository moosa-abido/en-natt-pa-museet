
namespace Museet.Models
{
    // TODO: Needs further work
    public class Art
    {   
        public Art(string art_id, string creator, string artdec)
        {
            this.ArtID = art_id;
            this.Creator = creator;
            this.Description = artdec;

        }
        public string ArtID { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public override string ToString()
        {
            return ArtID + ": Created by: " + Creator + ". " + Description;
        }
    }

}