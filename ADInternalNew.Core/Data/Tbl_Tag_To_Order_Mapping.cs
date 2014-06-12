using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Tag_To_Order_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Tag_To_Order_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Tags_Id,int Order_Detail_Id)
		{
			try{
				Tag_To_Order_Mapping objTag_To_Order_Mapping=new Tag_To_Order_Mapping();
				objTag_To_Order_Mapping.Tags_Id=Tags_Id;
				objTag_To_Order_Mapping.Order_Detail_Id=Order_Detail_Id;
				context.Tag_To_Order_Mappings.InsertOnSubmit(objTag_To_Order_Mapping);
				context.SubmitChanges();
				return objTag_To_Order_Mapping.Tag_To_Order_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Tag_To_Order_Mapping_Id,int Tags_Id,int Order_Detail_Id)
		{
			try{
				Tag_To_Order_Mapping objTag_To_Order_Mapping = (from i in context.Tag_To_Order_Mappings where i.Tag_To_Order_Mapping_Id == Tag_To_Order_Mapping_Id select i).SingleOrDefault();
				if (objTag_To_Order_Mapping != null)
				{
					objTag_To_Order_Mapping.Tags_Id=Tags_Id;
					objTag_To_Order_Mapping.Order_Detail_Id=Order_Detail_Id;
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
		 public Tag_To_Order_Mapping selectOne(int Tag_To_Order_Mapping_Id)
		{
			try
			{
				return (from i in context.Tag_To_Order_Mappings where i.Tag_To_Order_Mapping_Id == Tag_To_Order_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Tag_To_Order_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Tag_To_Order_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

