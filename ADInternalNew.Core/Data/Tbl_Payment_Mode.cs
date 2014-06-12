using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Payment_Mode
	{
		AdmisInternalDataContext context;
		public Tbl_Payment_Mode(AdmisInternalDataContext pcontext = null)
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
		public int add(string Payment_Mode_Name)
		{
			try{
				Payment_Mode objPayment_Mode=new Payment_Mode();
				objPayment_Mode.Payment_Mode_Name=Payment_Mode_Name;
				context.Payment_Modes.InsertOnSubmit(objPayment_Mode);
				context.SubmitChanges();
				return objPayment_Mode.Payment_Mode_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Payment_Mode_Id,string Payment_Mode_Name)
		{
			try{
				Payment_Mode objPayment_Mode = (from i in context.Payment_Modes where i.Payment_Mode_Id == Payment_Mode_Id select i).SingleOrDefault();
				if (objPayment_Mode != null)
				{
					objPayment_Mode.Payment_Mode_Name=Payment_Mode_Name;
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
		 public Payment_Mode selectOne(int Payment_Mode_Id)
		{
			try
			{
				return (from i in context.Payment_Modes where i.Payment_Mode_Id == Payment_Mode_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Payment_Mode> selectAll()
		{
			try
			{
				return (from i in context.Payment_Modes  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

