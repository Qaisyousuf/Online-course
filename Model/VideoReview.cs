using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VideoReview:EntityBase
    {
        public string MainTitle { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public string CountryFlagUrl { get; set; }
        public string CountryName { get; set; }
        public string VideoUrl { get; set; }
        public DateTime ProgramCompletionDate { get; set; }
        public string ProgramImageUrl { get; set; }

    }
}
