using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeTube.Data
{
    public class Movie
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public bool Recommended{get;set;}

        public string StorageUrl { get; set; }

        public string DownloadUrl {get;set;}

        public int Rating { get; set; }

        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; set; }

        public long ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }


        public long CommentId { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

      

    }
}
