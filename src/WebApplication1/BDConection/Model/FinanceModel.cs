using BDConection.Dto.Common;
using BDConection.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDConection.Model
{
    public class FinanceModel
    {
        public FinanceModel()
        {
        }

        public BasicResponse GeneratePaysheets(DateTime date)
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    context.st_GeneratePaysheets(date);
                    
                    return new BasicResponse
                    {
                        isSaved = true,
                        Message = "Success"
                    };

                }
            }
            catch (Exception ex)
            {
                return new BasicResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }

        public GetPaySheetsResponse GetPaySheets(int? Userid)
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    var result = context.st_GetPaysheets(Userid).ToList();
                    if (result?.Count == 0)
                    {
                        return new GetPaySheetsResponse
                        {
                            isSaved = false,
                            Message = "0 PaySheets or Error"
                        };
                    }
                    List<PaySheet> sheets = result.Select(u => new PaySheet
                    {
                        BreakFast = u.BreakFast,
                        FirstLastName = u.FirstLastName,
                        Name = u.Name,
                        Salary = u.Salary,
                        Savings = u.Savings,
                        SecondLastName = u.SecondLastName,
                        Userid = u.Userid,
                        Deposit = u.Deposit.Value,
                        EndDate = u.EndDate,
                        Paysheetid = u.Paysheetid,
                        StartDate = u.StartDate
                    }).ToList();

                    return new GetPaySheetsResponse
                    {
                        isSaved = true,
                        Message = "Success",
                        paySheets = sheets
                    };

                }
            }
            catch (Exception ex)
            {
                return new GetPaySheetsResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }

        public GetPaySheetsResponse GetPaySheetById(int id)
        {
            try
            {
                using (var context = new TempBDEntities())
                {
                    var result = context.st_GetPaysheetByid(id).ToList();
                    if (result?.Count == 0)
                    {
                        return new GetPaySheetsResponse
                        {
                            isSaved = false,
                            Message = "No PaySheet or Error"
                        };
                    }
                    List<PaySheet> sheets = result.Select(u => new PaySheet
                    {
                        BreakFast = u.BreakFast,
                        FirstLastName = u.FirstLastName,
                        Name = u.Name,
                        Salary = u.Salary,
                        Savings = u.Savings,
                        SecondLastName = u.SecondLastName,
                        Userid = u.Userid,
                        Deposit = u.Deposit.Value,
                        EndDate = u.EndDate,
                        Paysheetid = u.Paysheetid,
                        StartDate = u.StartDate
                    }).ToList();

                    return new GetPaySheetsResponse
                    {
                        isSaved = true,
                        Message = "Success",
                        paySheets = sheets
                    };

                }
            }
            catch (Exception ex)
            {
                return new GetPaySheetsResponse
                {
                    isSaved = false,
                    Message = ex.Message
                };
            }
        }


    }
}
