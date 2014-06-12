using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Special_Offer
	{
		AdmisInternalDataContext context;
		public Tbl_Special_Offer(AdmisInternalDataContext pcontext = null)
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
		public int add(int Count,DateTime Start_Date,DateTime End_Date,int Discount_Id)
		{
			try{
				Special_Offer objSpecial_Offer=new Special_Offer();
				objSpecial_Offer.Count=Count;
				objSpecial_Offer.Start_Date=Start_Date;
				objSpecial_Offer.End_Date=End_Date;
				objSpecial_Offer.Discount_Id=Discount_Id;
				context.Special_Offers.InsertOnSubmit(objSpecial_Offer);
				context.SubmitChanges();
				return objSpecial_Offer.Special_Offer_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Special_Offer_Id,int Count,DateTime Start_Date,DateTime End_Date,int Discount_Id)
		{
			try{
				Special_Offer objSpecial_Offer = (from i in context.Special_Offers where i.Special_Offer_Id == Special_Offer_Id select i).SingleOrDefault();
				if (objSpecial_Offer != null)
				{
					objSpecial_Offer.Count=Count;
					objSpecial_Offer.Start_Date=Start_Date;
					objSpecial_Offer.End_Date=End_Date;
					objSpecial_Offer.Discount_Id=Discount_Id;
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
		 public Special_Offer selectOne(int Special_Offer_Id)
		{
			try
			{
				return (from i in context.Special_Offers where i.Special_Offer_Id == Special_Offer_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Special_Offer> selectAll()
		{
			try
			{
				return (from i in context.Special_Offers  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

