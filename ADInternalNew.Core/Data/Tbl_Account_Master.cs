using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADInternalNew.DAL;
namespace ADInternalNew.CORE.Data{
	public  class Tbl_Account_Master
	{
		AdmisInternalDataContext context;
		public Tbl_Account_Master(AdmisInternalDataContext pcontext = null)
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
		public int add(int User_Id,decimal Debit_Amount,decimal Credit_Amount)
		{
			try{
				Account_Master objAccount_Master=new Account_Master();
				objAccount_Master.User_Id=User_Id;
				objAccount_Master.Debit_Amount=Debit_Amount;
				objAccount_Master.Credit_Amount=Credit_Amount;
				context.Account_Masters.InsertOnSubmit(objAccount_Master);
				context.SubmitChanges();
				return objAccount_Master.Account_Master_Id;
			}
			catch (Exception ex)
			{
				return 0;
			}
		}
		public bool udpate(int Account_Master_Id,int User_Id,decimal Debit_Amount,decimal Credit_Amount)
		{
			try{
				Account_Master objAccount_Master = (from i in context.Account_Masters where i.Account_Master_Id == Account_Master_Id select i).SingleOrDefault();
				if (objAccount_Master != null)
				{
					objAccount_Master.User_Id=User_Id;
					objAccount_Master.Debit_Amount=Debit_Amount;
					objAccount_Master.Credit_Amount=Credit_Amount;
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
		 public Account_Master selectOne(int Account_Master_Id)
		{
			try
			{
				return (from i in context.Account_Masters where i.Account_Master_Id == Account_Master_Id select i).SingleOrDefault();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
 		public List<Account_Master> selectAll()
		{
			try
			{
				return (from i in context.Account_Masters  select i).ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}

