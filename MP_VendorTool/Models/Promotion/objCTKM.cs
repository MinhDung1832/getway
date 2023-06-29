using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MP_VendorTool.Models.Promotion
{
    public class objCTKM
    {
        public string MaCTKM { set; get; }
        public string TenCTKM { set; get; }
        public string MaHang { set; get; }
        public string TenHang { set; get; }
        public string stepAmount { set; get; }
        public string MaQua { set; get; }

        public decimal DiscountAmountInVAT { set; get; }
        public decimal DealPriceDisc { set; get; }
        public decimal NoOfItemsNeeded { set; get; }
        public decimal SL_Hang { set; get; }

        public decimal L4LSL { set; get; }
        public decimal L4LDT { set; get; }
        public decimal L4LDS { set; get; }
        public decimal L4LGP { set; get; }
        public decimal XH631 { set; get; }
        public string Range { set; get; }

    }
    public class RouteInfo
    {
        public int RespId { get; set; }
        public string RespMsg { get; set; }
        public bool codeReturn { get; set; }
        public Array PushSalesLine { get; set; }
    }
    public class ObjPromotion
    {
        public string SourcePromotionHeader { get; set; }
        public string SourceDiscountOffers { get; set; }
        public string SourceMemberPointOffer { get; set; }
        public string SourceItemPointOffer { get; set; }
        public string SourceMixMatch { get; set; }
        public string SourceMultibuyDiscount { get; set; }
        public string SourceTenderTypeOffer { get; set; }
        public string SourceTotalDiscountOffer { get; set; }
        public string SourceTotalDiscountOfferLine { get; set; }
        public string SourceDieuKien { get; set; }
        public string SourceGroupKM { get; set; }
        public string SourcePopupMixMatch { get; set; }
        public string SourcePromotion { get; set; }
        public string SourcePopupPriceGroup { get; set; }
        public string SourceMixMaxLine { get; set; }
    }
    public class ObjGroupSPKM
    {
        public string MaCTKM { get; set; }
        public string MaHang { get; set; }
        public string Name { get; set; }
        public string xh361 { get; set; }
        public string lineGroup { get; set; }
        public string range { get; set; }

    }

    public class ObjComboxCTKM
    {
        public string Store_GType_Value { get; set; }
        public string Store_GType_Name { get; set; }
        public string StoreGroup_Value { get; set; }
        public string StoreGroup_Name { get; set; }
        public string DiscountType_Value { get; set; }
        public string DiscountType_Name { get; set; }
        public string LineSpecific_Value { get; set; }
        public string LineSpecific_Name { get; set; }
    }


    public class ObjMemberPointOffer
    {
        public string TypeCTKM { get; set; }
        public string CodeKM { get; set; }
        public string LineSpecific { get; set; }
        public string ValueType { get; set; }
        public string PointOfferValue { get; set; }
    }

    public class ObjItemPointOffer
    {
        public string CodeKM { get; set; }
        public string MemberPoint { get; set; }
        public string DiscAmount { get; set; }
        public string Discount { get; set; }
    }


    public class ObjMixMatch
    {
        public string discountType { get; set; }
        public string dealPriceValue { get; set; }
        public string discValue { get; set; }
        public string discountAmoutValue { get; set; }
        public string noOfLeastItem { get; set; }
        public string Leastexp { get; set; }
        public string SameDifLine { get; set; }
        public string NoTimeApp { get; set; }

    }

    public class ObjMixMatchLineGroup
    {
        public string MixDiscountType { get; set; }
        public string GroupNo { get; set; }
        public string LineGroupCode { get; set; }
        public string lineGroupType { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
    public class ObjMixMatchLine
    {
        public string codeKM { get; set; }
        public string Type { get; set; }
        public string No { get; set; }
        public string Description { get; set; }
        public string NoItemNeeded { get; set; }
        public string DealPriceDiscPercent { get; set; }
        public string DiscType { get; set; }
        public string LineGroup { get; set; }
    }
    public class ObjMultibuyDiscounts
    {
        public string DiscType { get; set; }
        public string MaHang { get; set; }
        public string Name { get; set; }
        public string SLMuaTT { get; set; }
        public string percentDown { get; set; }
        public string valueDown { get; set; }
        public string valueDeal { get; set; }
    }
    public class TenderTypeOffer
    {
        public string CodeKM { get; set; }
        public string TenderOffer { get; set; }
        public string TenderOfferAmount { get; set; }
    }
    public class objTotalDiscountOffer
    {
        public string CodeKM { get; set; }
        public string StepAmount { get; set; }
        public string No { get; set; }
        public string Type { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
    }
    public class ObjPromotions
    {
        public string CodeKM { get; set; }
        public string MaHang { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string xh361 { get; set; }
        public string range { get; set; }
        public string DiscStdPrice { get; set; }
        public string DiscAmountStdPrice { get; set; }
        public string phuongphap { get; set; }
    }

    public class ObjDiscountOffer
    {
        public string CodeKM { get; set; }
        public string MaHang { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string xh361 { get; set; }
        public string range { get; set; }
        public string DiscStdPrice { get; set; }
        public string DiscAmountStdPrice { get; set; }
        public string phuongphap { get; set; }
    }

    public class ObjDKHCKHUYENMAI
    {
        public string CodeKM { get; set; }
        public string Content { get; set; }
        public string Note { get; set; }
        public string Promotion { get; set; }
        public string DiscountOffer { get; set; }
        public string LineDiscOffer { get; set; }
        public string MultibuyDiscount { get; set; }
        public string MixMatch { get; set; }
        public string TotalDiscOffer { get; set; }
        public string TenderTypeOffer { get; set; }
        public string MemberPointOffer { get; set; }
        public string ItemPointOffer { get; set; }
    }

    public class objComboxKM
    {
        public string Code { set; get; }
        public string Name { set; get; }

    }
    public class objCombox
    {
        public string Code { set; get; }
        public string Name { set; get; }

    }
    public class ObjPromotionHeader
    {
        public string TypeCTKM { get; set; }
        public string TargetCTKM { get; set; }
        public string CodeKM { get; set; }
        public string NameKM { get; set; }
        public string ToDate { get; set; }
        public string FrDate { get; set; }
        public string Vonglap_DKy { get; set; }
        public string Range { get; set; }
        public string StoreGroupType { get; set; }
        public string StoreGroup { get; set; }
        public string StoreChannel { get; set; }
        public string POSPopupMessage1 { get; set; }
        public string POSPopupMessage2 { get; set; }
        public string POSPopupMessage3 { get; set; }
        public string PriceGroup { get; set; }
        public string CustomerDiscGroup { get; set; }
        public string CouponCode { get; set; }
        public string CouponQtyNeeded { get; set; }
        public string SalesTypeFilter { get; set; }
        public string AmountToTrigger { get; set; }
        public string MemberType { get; set; }
        public string MemberValue { get; set; }
        public string MemberAttibute { get; set; }
        public string MemberAttibuteValue { get; set; }
        public string TenderTypeCode { get; set; }
        public string TenderTypeValue { get; set; }
        public string Status { get; set; }
    }


}
