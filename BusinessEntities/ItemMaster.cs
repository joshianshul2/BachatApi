using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ItemMasterEntity
    {
       
        public int PK_ItemId { get; set; }
        public string CategoryName { get; set; }
        public string IsActive { get; set; }
        public string SubCategoryName { get; set; }
        public int ItemName { get; set; }
        public string Rate { get; set; }
        public string OfferRate { get; set; }
        public string ImageName { get; set; }
        public string Discount { get; set; }
        public int IsCOD { get; set; }
        public string IsFreeDel { get; set; }
        public string ShowFrontTop_3 { get; set; }
        public string ShowFrontMid_3 { get; set; }
        public string ShowFrontBottom_3 { get; set; }
        public string ShowFrontSlider_10 { get; set; }
        public string ShowLeftFront_5 { get; set; }
        public string ShowFrontSingle_1 { get; set; }
        public int ShowTop3 { get; set; }
        public string ShowBottom9 { get; set; }
        public string ShowSlider9 { get; set; }
        public string ShowLeft5 { get; set; }
        public string Position { get; set; }
        public int FrontPosition { get; set; }
        public string CreateDate { get; set; }

    }
}
