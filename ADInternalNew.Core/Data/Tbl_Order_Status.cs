using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Status
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Status(AdmisInternalDataContext pcontext = null)
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
		public int add(string Order_Status_Name)
		{
			try{
				Order_Status objOrder_Status=new Order_Status();
				objOrder_Status.Order_Status_Name=Order_Status_Name;
				context.Order_Status.InsertOnSubmit(objOrder_Status);
				context.SubmitChanges();
				return objOrder_Status.Order_Status_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Status_Id,string Order_Status_Name)
		{
			try{
				Order_Status objOrder_Status = (from i in context.Order_Status where i.Order_Status_Id == Order_Status_Id select i).SingleOrDefault();
				if (objOrder_Status != null)
				{
					objOrder_Status.Order_Status_Name=Order_Status_Name;
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
		 public Order_Status selectOne(int Order_Status_Id)
		{
			try
			{
				return (from i in context.Order_Status where i.Order_Status_Id == Order_Status_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Status> selectAll()
		{
			try
			{
				return (from i in context.Order_Status  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

