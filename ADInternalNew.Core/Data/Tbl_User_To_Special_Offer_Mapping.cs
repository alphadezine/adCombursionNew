using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_To_Special_Offer_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_To_Special_Offer_Mapping(AdmisInternalDataContext pcontext = null)
		{
			if (context == null)
			{
				context = new AdmisInternalDataContext();
			}
			else
			{
				context = pcontext;
			}
		}
		public int add(int Special_Offer_Id,int User_Id,string Coupon_Code)
		{
			try{
				User_To_Special_Offer_Mapping objUser_To_Special_Offer_Mapping=new User_To_Special_Offer_Mapping();
				objUser_To_Special_Offer_Mapping.Special_Offer_Id=Special_Offer_Id;
				objUser_To_Special_Offer_Mapping.User_Id=User_Id;
				objUser_To_Special_Offer_Mapping.Coupon_Code=Coupon_Code;
				context.User_To_Special_Offer_Mappings.InsertOnSubmit(objUser_To_Special_Offer_Mapping);
				context.SubmitChanges();
				return objUser_To_Special_Offer_Mapping.User_To_Special_Offer_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int User_To_Special_Offer_Mapping_Id,int Special_Offer_Id,int User_Id,string Coupon_Code)
		{
			try{
				User_To_Special_Offer_Mapping objUser_To_Special_Offer_Mapping = (from i in context.User_To_Special_Offer_Mappings where i.User_To_Special_Offer_Mapping_Id == User_To_Special_Offer_Mapping_Id select i).SingleOrDefault();
				if (objUser_To_Special_Offer_Mapping != null)
				{
					objUser_To_Special_Offer_Mapping.Special_Offer_Id=Special_Offer_Id;
					objUser_To_Special_Offer_Mapping.User_Id=User_Id;
					objUser_To_Special_Offer_Mapping.Coupon_Code=Coupon_Code;
					context.SubmitChanges();
					return true;
				}
				else
				{
					return false;
				}
 			}
			catch (Exception ex)
			{
				return false;
			}
		}
		 public User_To_Special_Offer_Mapping selectOne(int User_To_Special_Offer_Mapping_Id)
		{
			try
			{
				return (from i in context.User_To_Special_Offer_Mappings where i.User_To_Special_Offer_Mapping_Id == User_To_Special_Offer_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_To_Special_Offer_Mapping> selectAll()
		{
			try
			{
				return (from i in context.User_To_Special_Offer_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

