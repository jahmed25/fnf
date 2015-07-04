using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;
using MFO.Common;

/// <summary>
/// Summary description for MenuUserClass
/// </summary>
/// 

namespace MFO.DAO
{
    public class MenuUserDAO
    {

        public DataTable getViewImageNewMaster()
        {
            return GenericDAO.getDataTable(@"select Inventory,
                                                    Color,
                                                    WashCare,
                                                    Material,
                                                    ShippingReturns,
                                                    SKUProductDetails,
                                                    SKULongDescription,
                                                    PathBackInternaldetailsSmallImage,
                                                    PathDimensionalInternalImage,
                                                    PathBackInternalImage,
                                                    PathLowerInternalImage,
                                                    PathUpperInternalImage,
                                                    PathIndexInternalImage,
                                                    PathLowerInternaldetailsSmallImage,
                                                    PathUpperInternaldetailsSmallImage,
                                                    PathInternaldetailsHoverImage,
                                                    PathUpperInternaldetailsHoverImage,
                                                    PathLowerInternaldetailsHoverImage,
                                                    PathBackInternaldetailsHoverImage,
                                                    PathInternaldetailsZoomImage,
                                                    PathUpperInternaldetailsZoomImage,
                                                    PathLowerInternaldetailsZoomImage,
                                                    PathBackInternaldetailsZoomImage,
                                                    PathBackInternaldetailsHoverImage, 
                                                    CategoryTypeUrlName,ProductNewID,
                                                    CategoryID,CategoryTypeID,StyleCode,
                                                    RecordStatus,Size,
                                                    ProductTypeID,
                                                    MRP,
                                                    MetaKeywords,
                                                    SKUCategory,
                                                    SKUCategoryType,
													SKUStatus,
													SpecialPrice,
													SKUName,
													SKUBrand,
													SKUCode,
													VariantType,
													SKUClassification,
													SizeDataType,
													PathInternaldetailsSmallImage,
													SKUProductType,
													ColorCode,
                                                    SKUNameHindi
													from PRODUCTS");//where SKUStatus='Active' and RecordStatus='1'"
        }

    }
}