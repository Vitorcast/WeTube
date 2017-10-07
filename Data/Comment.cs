using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WeTube.Data
{
    public class Comment
    {
        public long Id { get; set; }
        public string Description { get; set; }

        public int? MediaItemId {get;set;}
        public virtual Movie MediaItem { get; set; }
       

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser CommentedBy { get; set; }

        [ConcurrencyCheck]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TimeStamp { get; set; }
    }
}
