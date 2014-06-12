using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Payment_To_Invoice_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Payment_To_Invoice_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Payment_Id,int Invoice_Id,decimal Pending_Amount)
		{
			try{
				Payment_To_Invoice_Mapping objPayment_To_Invoice_Mapping=new Payment_To_Invoice_Mapping();
				objPayment_To_Invoice_Mapping.Payment_Id=Payment_Id;
				objPayment_To_Invoice_Mapping.Invoice_Id=Invoice_Id;
				objPayment_To_Invoice_Mapping.Pending_Amount=Pending_Amount;
				context.Payment_To_Invoice_Mappings.InsertOnSubmit(objPayment_To_Invoice_Mapping);
				context.SubmitChanges();
				return objPayment_To_Invoice_Mapping.Payment_To_Invoice_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Payment_To_Invoice_Mapping_Id,int Payment_Id,int Invoice_Id,decimal Pending_Amount)
		{
			try{
				Payment_To_Invoice_Mapping objPayment_To_Invoice_Mapping = (from i in context.Payment_To_Invoice_Mappings where i.Payment_To_Invoice_Mapping_Id == Payment_To_Invoice_Mapping_Id select i).SingleOrDefault();
				if (objPayment_To_Invoice_Mapping != null)
				{
					objPayment_To_Invoice_Mapping.Payment_Id=Payment_Id;
					objPayment_To_Invoice_Mapping.Invoice_Id=Invoice_Id;
					objPayment_To_Invoice_Mapping.Pending_Amount=Pending_Amount;
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
		 public Payment_To_Invoice_Mapping selectOne(int Payment_To_Invoice_Mapping_Id)
		{
			try
			{
				return (from i in context.Payment_To_Invoice_Mappings where i.Payment_To_Invoice_Mapping_Id == Payment_To_Invoice_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Payment_To_Invoice_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Payment_To_Invoice_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

