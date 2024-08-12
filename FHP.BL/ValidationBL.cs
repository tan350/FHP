using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FHP.RES;
using FHP.VO;
using FHP.DL;
using FHPDL.IFT;
using static FHP.RES.Education_Level;


namespace FHP.BL
{
    public class ValidationBL
    {
        RecordVO connectionRecord = new RecordVO
        {
            connectDatabase = true,
        };

        private readonly IRecordDL recordFileManager;
        public ValidationBL()
        {
            if (connectionRecord.connectDatabase)
            {
                recordFileManager = new FHPSqlDL();
            }
            else
            {
                recordFileManager = new FileHandlingDL();
            }
        }

        public bool Validate(RecordVO record)
        {
            if (record.editMode == EditMode.New || record.editMode == EditMode.Edit)
            {
                if (record.FirstName == "")
                {
                    record.validationMessage = Message.FirstNameRequired;
                    return false;
                }
                else if (record.Qualification == "")
                {
                    record.validationMessage = Message.QualificationRequired;
                    return false;
                }
                else if (record.CurrentCompany == "")
                {
                    record.validationMessage = Message.CurrentCompanyRequired;
                    return false;
                }
                else if (record.DOB >= DateTime.Now)
                {
                    record.validationMessage = Message.DateOfBirthInvalid;
                    return false;
                }
                else if (record.DOJ > DateTime.Now)
                {
                    record.validationMessage = Message.JoiningDateInvalid;
                    return false;
                }
                else if (record.DOB >= record.DOJ)
                {
                    record.validationMessage = Message.DateOfBirthIsMore;
                    return false;
                }
            }
            return true;
        }

        public bool Save(RecordVO record)
        {
            if (Validate(record))
            {
                if (record.editMode == EditMode.New)
                {
                    if (!recordFileManager.FinalSave(record))
                    {
                        record.validationMessage = Message.InvalidFormData;
                        return false;
                    }
                }
                else if (record.editMode == EditMode.Edit)
                {
                    recordFileManager.FinalSave(record);
                }
                else if (record.editMode == EditMode.Delete)
                {
                    recordFileManager.FinalSave(record);
                }
                return true;
            }
            return false;
        }

        public List<RecordVO> ReadAllRecordsData()
        {
            return recordFileManager.ReadAllRecords();
        }

        public long GetNextSrNumber()
        {
            long newSrNo = recordFileManager.NewRecordSrNo();
            return newSrNo;
        }

        public RecordVO GetRecordUsingSrNo(long SrNo)
        {
            RecordVO record = new RecordVO();
            record = recordFileManager.GetRecordBySrNo(SrNo);
            return record;
        }

    }

}
