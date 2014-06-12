using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Payment
	{
		AdmisInternalDataContext context;
		public Tbl_Payment(AdmisInternalDataContext pcontext = null)
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
		public int add(int Payment_Mode_Id,int Payment_Type_Id,int Payer_User_Id,int Receiver_User_Id)
		{
			try{
				Payment objPayment=new Payment();
				objPayment.Payment_Mode_Id=Payment_Mode_Id;
				objPayment.Payment_Type_Id=Payment_Type_Id;
				objPayment.Payer_User_Id=Payer_User_Id;
				objPayment.Receiver_User_Id=Receiver_User_Id;
				context.Payments.InsertOnSubmit(objPayment);
				context.SubmitChanges();
				return objPayment.Payment_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Payment_Id,int Payment_Mode_Id,int Payment_Type_Id,int Payer_User_Id,int Receiver_User_Id)
		{
			try{
				Payment objPayment = (from i in context.Payments where i.Payment_Id == Payment_Id select i).SingleOrDefault();
				if (objPayment != null)
				{
					objPayment.Payment_Mode_Id=Payment_Mode_Id;
					objPayment.Payment_Type_Id=Payment_Type_Id;
					objPayment.Payer_User_Id=Payer_User_Id;
					objPayment.Receiver_User_Id=Receiver_User_Id;
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
		 public Payment selectOne(int Payment_Id)
		{
			try
			{
				return (from i in context.Payments where i.Payment_Id == Payment_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Payment> selectAll()
		{
			try
			{
				return (from i in context.Payments  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

