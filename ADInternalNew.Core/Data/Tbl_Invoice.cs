using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Invoice
	{
		AdmisInternalDataContext context;
		public Tbl_Invoice(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_Detail_Id,decimal Original_Order_Amount,int Discount_Id,decimal Final_Amount,int Invoice_Status,int TimeStamp_Id)
		{
			try{
				Invoice objInvoice=new Invoice();
				objInvoice.Order_Detail_Id=Order_Detail_Id;
				objInvoice.Original_Order_Amount=Original_Order_Amount;
				objInvoice.Discount_Id=Discount_Id;
				objInvoice.Final_Amount=Final_Amount;
				objInvoice.Invoice_Status=Invoice_Status;
				objInvoice.TimeStamp_Id=TimeStamp_Id;
				context.Invoices.InsertOnSubmit(objInvoice);
				context.SubmitChanges();
				return objInvoice.Invoice_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Invoice_Id,int Order_Detail_Id,decimal Original_Order_Amount,int Discount_Id,decimal Final_Amount,int Invoice_Status,int TimeStamp_Id)
		{
			try{
				Invoice objInvoice = (from i in context.Invoices where i.Invoice_Id == Invoice_Id select i).SingleOrDefault();
				if (objInvoice != null)
				{
					objInvoice.Order_Detail_Id=Order_Detail_Id;
					objInvoice.Original_Order_Amount=Original_Order_Amount;
					objInvoice.Discount_Id=Discount_Id;
					objInvoice.Final_Amount=Final_Amount;
					objInvoice.Invoice_Status=Invoice_Status;
					objInvoice.TimeStamp_Id=TimeStamp_Id;
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
		 public Invoice selectOne(int Invoice_Id)
		{
			try
			{
				return (from i in context.Invoices where i.Invoice_Id == Invoice_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Invoice> selectAll()
		{
			try
			{
				return (from i in context.Invoices  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

