using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Template_To_Special_Offer_Mapping
	{
		AdmisInternalDataContext context;
		public Tbl_Template_To_Special_Offer_Mapping(AdmisInternalDataContext pcontext = null)
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
		public int add(int Template_Id,int Special_Offer_Id)
		{
			try{
				Template_To_Special_Offer_Mapping objTemplate_To_Special_Offer_Mapping=new Template_To_Special_Offer_Mapping();
				objTemplate_To_Special_Offer_Mapping.Template_Id=Template_Id;
				objTemplate_To_Special_Offer_Mapping.Special_Offer_Id=Special_Offer_Id;
				context.Template_To_Special_Offer_Mappings.InsertOnSubmit(objTemplate_To_Special_Offer_Mapping);
				context.SubmitChanges();
				return objTemplate_To_Special_Offer_Mapping.Template_To_Special_Offer_Mapping_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Template_To_Special_Offer_Mapping_Id,int Template_Id,int Special_Offer_Id)
		{
			try{
				Template_To_Special_Offer_Mapping objTemplate_To_Special_Offer_Mapping = (from i in context.Template_To_Special_Offer_Mappings where i.Template_To_Special_Offer_Mapping_Id == Template_To_Special_Offer_Mapping_Id select i).SingleOrDefault();
				if (objTemplate_To_Special_Offer_Mapping != null)
				{
					objTemplate_To_Special_Offer_Mapping.Template_Id=Template_Id;
					objTemplate_To_Special_Offer_Mapping.Special_Offer_Id=Special_Offer_Id;
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
		 public Template_To_Special_Offer_Mapping selectOne(int Template_To_Special_Offer_Mapping_Id)
		{
			try
			{
				return (from i in context.Template_To_Special_Offer_Mappings where i.Template_To_Special_Offer_Mapping_Id == Template_To_Special_Offer_Mapping_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Template_To_Special_Offer_Mapping> selectAll()
		{
			try
			{
				return (from i in context.Template_To_Special_Offer_Mappings  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

