using System.Runtime.Serialization;

namespace WebDevPortRn.Models
{
    [DataContract]
    public class GetPhotoModel
    {
        [DataMember]
        public string copyright {  get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string explanation { get; set; }

        [DataMember]
        public string hdurl { get; set; }

        [DataMember]
        public string media_type { get; set; }

        [DataMember]
        public string service_version { get; set; }

        [DataMember]
        public string title { get; set; }

        [DataMember]
        public string url { get; set; }

        public GetPhotoModel()
        {
            copyright = string.Empty;
            date = DateTime.Now;
            explanation = string.Empty;
            hdurl = string.Empty;
            media_type = string.Empty;
            service_version = string.Empty;
            title = string.Empty;
            url = string.Empty;
        }
    }
}
