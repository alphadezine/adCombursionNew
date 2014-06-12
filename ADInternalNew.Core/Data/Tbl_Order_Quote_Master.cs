using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Order_Quote_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Order_Quote_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(int Order_To_User_Mapping_Id,decimal Original_Order_Amount,decimal Additional_Amount)
		{
			try{
				Order_Quote_Master objOrder_Quote_Master=new Order_Quote_Master();
				objOrder_Quote_Master.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
				objOrder_Quote_Master.Original_Order_Amount=Original_Order_Amount;
				objOrder_Quote_Master.Additional_Amount=Additional_Amount;
				context.Order_Quote_Masters.InsertOnSubmit(objOrder_Quote_Master);
				context.SubmitChanges();
				return objOrder_Quote_Master.Order_Quote_Master_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Order_Quote_Master_Id,int Order_To_User_Mapping_Id,decimal Original_Order_Amount,decimal Additional_Amount)
		{
			try{
				Order_Quote_Master objOrder_Quote_Master = (from i in context.Order_Quote_Masters where i.Order_Quote_Master_Id == Order_Quote_Master_Id select i).SingleOrDefault();
				if (objOrder_Quote_Master != null)
				{
					objOrder_Quote_Master.Order_To_User_Mapping_Id=Order_To_User_Mapping_Id;
					objOrder_Quote_Master.Original_Order_Amount=Original_Order_Amount;
					objOrder_Quote_Master.Additional_Amount=Additional_Amount;
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
		 public Order_Quote_Master selectOne(int Order_Quote_Master_Id)
		{
			try
			{
				return (from i in context.Order_Quote_Masters where i.Order_Quote_Master_Id == Order_Quote_Master_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Order_Quote_Master> selectAll()
		{
			try
			{
				return (from i in context.Order_Quote_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

