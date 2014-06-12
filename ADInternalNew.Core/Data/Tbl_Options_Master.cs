using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Options_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Options_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(string Option_Value,int Questionnaire_Id)
		{
			try{
				Options_Master objOptions_Master=new Options_Master();
				objOptions_Master.Option_Value=Option_Value;
				objOptions_Master.Questionnaire_Id=Questionnaire_Id;
				context.Options_Masters.InsertOnSubmit(objOptions_Master);
				context.SubmitChanges();
				return objOptions_Master.Options_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Options_Id,string Option_Value,int Questionnaire_Id)
		{
			try{
				Options_Master objOptions_Master = (from i in context.Options_Masters where i.Options_Id == Options_Id select i).SingleOrDefault();
				if (objOptions_Master != null)
				{
					objOptions_Master.Option_Value=Option_Value;
					objOptions_Master.Questionnaire_Id=Questionnaire_Id;
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
		 public Options_Master selectOne(int Options_Id)
		{
			try
			{
				return (from i in context.Options_Masters where i.Options_Id == Options_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Options_Master> selectAll()
		{
			try
			{
				return (from i in context.Options_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

