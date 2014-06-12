using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Discount
	{
		AdmisInternalDataContext context;
		public Tbl_Discount(AdmisInternalDataContext pcontext = null)
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
		public int add(decimal Discount_Amount,int Discount_Type_Id,string Discount_Name,bool IsSpecialOffer)
		{
			try{
				Discount objDiscount=new Discount();
				objDiscount.Discount_Amount=Discount_Amount;
				objDiscount.Discount_Type_Id=Discount_Type_Id;
				objDiscount.Discount_Name=Discount_Name;
				objDiscount.IsSpecialOffer=IsSpecialOffer;
				context.Discounts.InsertOnSubmit(objDiscount);
				context.SubmitChanges();
				return objDiscount.Discount_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Discount_Id,decimal Discount_Amount,int Discount_Type_Id,string Discount_Name,bool IsSpecialOffer)
		{
			try{
				Discount objDiscount = (from i in context.Discounts where i.Discount_Id == Discount_Id select i).SingleOrDefault();
				if (objDiscount != null)
				{
					objDiscount.Discount_Amount=Discount_Amount;
					objDiscount.Discount_Type_Id=Discount_Type_Id;
					objDiscount.Discount_Name=Discount_Name;
					objDiscount.IsSpecialOffer=IsSpecialOffer;
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
		 public Discount selectOne(int Discount_Id)
		{
			try
			{
				return (from i in context.Discounts where i.Discount_Id == Discount_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Discount> selectAll()
		{
			try
			{
				return (from i in context.Discounts  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

