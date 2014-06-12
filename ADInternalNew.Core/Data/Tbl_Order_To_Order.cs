using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_To_Order
	{
		AdmisInternalDataContext context;
		public Tbl_Order_To_Order(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_Detail_Id,int Parent_Order_Detail_Id)
		{
			try{
				Order_To_Order objOrder_To_Order=new Order_To_Order();
				objOrder_To_Order.Order_Detail_Id=Order_Detail_Id;
				objOrder_To_Order.Parent_Order_Detail_Id=Parent_Order_Detail_Id;
				context.Order_To_Orders.InsertOnSubmit(objOrder_To_Order);
				context.SubmitChanges();
				return objOrder_To_Order.Order_To_Order_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_To_Order_Id,int Order_Detail_Id,int Parent_Order_Detail_Id)
		{
			try{
				Order_To_Order objOrder_To_Order = (from i in context.Order_To_Orders where i.Order_To_Order_Id == Order_To_Order_Id select i).SingleOrDefault();
				if (objOrder_To_Order != null)
				{
					objOrder_To_Order.Order_Detail_Id=Order_Detail_Id;
					objOrder_To_Order.Parent_Order_Detail_Id=Parent_Order_Detail_Id;
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
		 public Order_To_Order selectOne(int Order_To_Order_Id)
		{
			try
			{
				return (from i in context.Order_To_Orders where i.Order_To_Order_Id == Order_To_Order_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_To_Order> selectAll()
		{
			try
			{
				return (from i in context.Order_To_Orders  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

