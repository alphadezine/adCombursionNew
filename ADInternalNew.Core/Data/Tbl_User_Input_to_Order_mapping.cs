using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_User_Input_to_Order_mapping
	{
		AdmisInternalDataContext context;
		public Tbl_User_Input_to_Order_mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int user_to_input_mapping_id,int order_detail_id)
		{
			try{
				User_Input_to_Order_mapping objUser_Input_to_Order_mapping=new User_Input_to_Order_mapping();
				objUser_Input_to_Order_mapping.user_to_input_mapping_id=user_to_input_mapping_id;
				objUser_Input_to_Order_mapping.order_detail_id=order_detail_id;
				context.User_Input_to_Order_mappings.InsertOnSubmit(objUser_Input_to_Order_mapping);
				context.SubmitChanges();
				return objUser_Input_to_Order_mapping.user_input_to_order_mapping_id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int user_input_to_order_mapping_id,int user_to_input_mapping_id,int order_detail_id)
		{
			try{
				User_Input_to_Order_mapping objUser_Input_to_Order_mapping = (from i in context.User_Input_to_Order_mappings where i.user_input_to_order_mapping_id == user_input_to_order_mapping_id select i).SingleOrDefault();
				if (objUser_Input_to_Order_mapping != null)
				{
					objUser_Input_to_Order_mapping.user_to_input_mapping_id=user_to_input_mapping_id;
					objUser_Input_to_Order_mapping.order_detail_id=order_detail_id;
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
		 public User_Input_to_Order_mapping selectOne(int user_input_to_order_mapping_id)
		{
			try
			{
				return (from i in context.User_Input_to_Order_mappings where i.user_input_to_order_mapping_id == user_input_to_order_mapping_id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<User_Input_to_Order_mapping> selectAll()
		{
			try
			{
				return (from i in context.User_Input_to_Order_mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

