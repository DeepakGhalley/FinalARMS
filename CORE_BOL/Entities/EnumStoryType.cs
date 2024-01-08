using System;
using System.Collections.Generic;

namespace CORE_BOL.Entities
{
    public partial class EnumStoryType
    {
        public EnumStoryType()
        {
            MstBuildingDetail = new HashSet<MstBuildingDetail>();
        }

        public int StoryTypeId { get; set; }
        public string StoryType { get; set; }

        public virtual ICollection<MstBuildingDetail> MstBuildingDetail { get; set; }
    }
}
