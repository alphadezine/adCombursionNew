using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Payment_Type
	{
		AdmisInternalDataContext context;
		public Tbl_Payment_Type(AdmisInternalDataContext pcontext = null)
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
		public int add(string Payment_Type_Value)
		{
			try{
				Payment_Type objPayment_Type=new Payment_Type();
				objPayment_Type.Payment_Type_Value=Payment_Type_Value;
				context.Payment_Types.InsertOnSubmit(objPayment_Type);
				context.SubmitChanges();
				return objPayment_Type.Payment_Type_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Payment_Type_Id,string Payment_Type_Value)
		{
			try{
				Payment_Type objPayment_Type = (from i in context.Payment_Types where i.Payment_Type_Id == Payment_Type_Id select i).SingleOrDefault();
				if (objPayment_Type != null)
				{
					objPayment_Type.Payment_Type_Value=Payment_Type_Value;
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
		 public Payment_Type selectOne(int Payment_Type_Id)
		{
			try
			{
				return (from i in context.Payment_Types where i.Payment_Type_Id == Payment_Type_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Payment_Type> selectAll()
		{
			try
			{
				return (from i in context.Payment_Types  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

