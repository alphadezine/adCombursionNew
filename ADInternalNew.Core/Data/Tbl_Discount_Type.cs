using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Discount_Type
	{
		AdmisInternalDataContext context;
		public Tbl_Discount_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string Discount_Type_Name)
		{
			try{
				Discount_Type objDiscount_Type=new Discount_Type();
				objDiscount_Type.Discount_Type_Name=Discount_Type_Name;
				context.Discount_Types.InsertOnSubmit(objDiscount_Type);
				context.SubmitChanges();
				return objDiscount_Type.Discount_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Discount_Type_Id,string Discount_Type_Name)
		{
			try{
				Discount_Type objDiscount_Type = (from i in context.Discount_Types where i.Discount_Type_Id == Discount_Type_Id select i).SingleOrDefault();
				if (objDiscount_Type != null)
				{
					objDiscount_Type.Discount_Type_Name=Discount_Type_Name;
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
		 public Discount_Type selectOne(int Discount_Type_Id)
		{
			try
			{
				return (from i in context.Discount_Types where i.Discount_Type_Id == Discount_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Discount_Type> selectAll()
		{
			try
			{
				return (from i in context.Discount_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

