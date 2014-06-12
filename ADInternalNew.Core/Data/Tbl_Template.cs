using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Template
	{
		AdmisInternalDataContext context;
		public Tbl_Template(AdmisInternalDataContext pcontext = null)
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
		public int add(string Template_Name)
		{
			try{
				Template objTemplate=new Template();
				objTemplate.Template_Name=Template_Name;
				context.Templates.InsertOnSubmit(objTemplate);
				context.SubmitChanges();
				return objTemplate.Template_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Template_Id,string Template_Name)
		{
			try{
				Template objTemplate = (from i in context.Templates where i.Template_Id == Template_Id select i).SingleOrDefault();
				if (objTemplate != null)
				{
					objTemplate.Template_Name=Template_Name;
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
		 public Template selectOne(int Template_Id)
		{
			try
			{
				return (from i in context.Templates where i.Template_Id == Template_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Template> selectAll()
		{
			try
			{
				return (from i in context.Templates  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

